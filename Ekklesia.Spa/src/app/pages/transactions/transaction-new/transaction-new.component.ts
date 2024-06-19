import { Component, OnInit } from '@angular/core'
import {
  AbstractControl,
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from '@angular/forms'
import { Router } from '@angular/router'
import { UtilsValidators } from 'src/app/utils/utils-validators'
import { Member } from 'src/app/models/Member'
import { Transaction } from 'src/app/models/Transaction'
import {
  TransactionEnum,
  TransactionMapping,
} from 'src/app/models/TransactionEnum'
import { MemberService } from 'src/app/services/member.service'
import { TransactionService } from 'src/app/services/transaction.service'
import { BaseConverter } from 'src/app/utils/base-converter'
import { finalize, pluck, tap } from 'rxjs'
import { NgxSpinnerService } from 'ngx-spinner'
import { ToastrService } from 'ngx-toastr'
import { Filtering } from 'src/app/models/Filtering'

@Component({
  selector: 'app-transaction-new',
  templateUrl: './transaction-new.component.html',
})
export class TransactionNewComponent implements OnInit {
  form: UntypedFormGroup
  types: (string | TransactionEnum)[]
  transactionMapping = TransactionMapping
  members: Member[]
  maxDate: Date
  minDate: Date
  

  get isDateInvalid(): boolean {
    return this.hasErros('date')
  }

  get isAmountInvalid(): boolean {
    return this.hasErros('amount')
  }

  get isDescriptionInvalid(): boolean {
    return this.hasErros('description')
  }

  get controls(): { [key: string]: AbstractControl } {
    return this.form.controls
  }

  constructor(
    private _transactioService: TransactionService,
    private _formBuilder: UntypedFormBuilder,
    private _memberService: MemberService,
    private _router: Router,
    private _spinner: NgxSpinnerService,
    private _toasterService: ToastrService
  ) {
    this.members = []
    this.types = Object.values(TransactionEnum).filter(
      (value) => typeof value === 'number',
    )
    this.maxDate = new Date()
    this.maxDate.setDate(this.maxDate.getDate() + 1)

    this.minDate = new Date()
    this.minDate.setMonth(this.maxDate.getMonth() - 1)

    this.form = this._formBuilder.group({
      date: [
        '',
        [
          Validators.required,
          UtilsValidators.maxDate(this.maxDate),
          UtilsValidators.minDate(this.minDate),
        ],
      ],
      amount: ['', [Validators.required, Validators.min(0.1)]],
      type: ['', [Validators.required]],
      description: ['', [Validators.maxLength(250)]],
      responsable: ['', [Validators.required]],
    })
  }

  ngOnInit(): void {
    this.controls.type.valueChanges.subscribe((type: number) => {
      if (type == TransactionEnum.DESPESA) {
        this.controls.description.setValidators(Validators.required)
      } else {
        this.controls.description.clearValidators()
      }
      this.controls.description.updateValueAndValidity()
    })

    
    this._memberService
      .all()
      .pipe(finalize(() => this._spinner.hide()))
      .subscribe((members: Member[]) => {        
        this.members = members
      })
  }

  onSave() {
    const transaction: Transaction = Object.assign(
      new Transaction(),
      this.form.value,
    )
    const observer = {
      next: (x: Response) => { this.form.markAsPristine(); this._router.navigate(['transaction']); },
      error: (error: any) => {
        this._toasterService.error(
          'Algo deu errado 😵. Tente novamente mais tarde.',
          'Erro',
        )
        console.error('Erro:' + error.statusText)
      },
    }

    this._transactioService
      .add(transaction)
      .pipe(finalize(() => this._spinner.hide()))
      .subscribe(observer)
  }

  onCancel() {
    this._router.navigate(['transaction'])
  }

  private hasErros(field: string): boolean {
    const hasErros =
      this.form.get(field)?.errors &&
      (this.form.get(field)?.dirty || this.form.get(field)?.touched)
    return Boolean(hasErros)
  }
}
