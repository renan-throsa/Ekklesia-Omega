import { Component, OnInit } from '@angular/core'
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms'
import { Router } from '@angular/router'
import { BaseConverter } from 'src/app/components/shared/base-converter'
import { CustomValidators } from 'src/app/components/shared/custom-validators'
import { Member } from 'src/app/models/Member'
import { Transaction } from 'src/app/models/Transaction'
import {
  TransactionEnum,
  TransactionMapping,
} from 'src/app/models/TransactionEnum'
import { MemberService } from 'src/app/services/member.service'
import { TransactionService } from 'src/app/services/transaction.service'

@Component({
  selector: 'app-transaction-new',
  templateUrl: './transaction-new.component.html',
})
export class TransactionNewComponent implements OnInit {
  form: FormGroup
  types: (string | TransactionEnum)[]
  transactionMapping = TransactionMapping
  members: Member[]
  maxDate: Date
  minDate: Date

  public get maxDateStr() {
    return BaseConverter.DateToStringOnlyDate(new Date(this.maxDate))
  }

  public get minDateStr() {
    return BaseConverter.DateToStringOnlyDate(new Date(this.minDate))
  }

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
    private _formBuilder: FormBuilder,
    private _memberService: MemberService,
    private _router: Router,
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
          CustomValidators.maxDate(this.maxDate),
          CustomValidators.minDate(this.minDate),
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
      }else{
        this.controls.description.clearValidators();
      }
      this.controls.description.updateValueAndValidity()
    })

    this._memberService.browse().subscribe((members: Member[]) => {
      this.members = members
    })
  }

  onSave() {
    const transaction: Transaction = Object.assign(
      new Transaction(),
      this.form.value,
    )       
    const observer = {
      next: (x: Response) => this._router.navigate(['transaction']),
      error: (err: any) => console.error('Observer got an error: ' + err),
    }
    this._transactioService.add(transaction).subscribe(observer)
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
