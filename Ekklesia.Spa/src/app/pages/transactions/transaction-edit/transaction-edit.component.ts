import { Component, OnInit } from '@angular/core'
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router'
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'
import { NgxSpinnerService } from 'ngx-spinner'
import { ToastrService } from 'ngx-toastr'
import { finalize } from 'rxjs'
import { CustomModalComponent } from 'src/app/components/custom-modal/custom-modal.component'
import { Member } from 'src/app/models/Member'
import { Transaction } from 'src/app/models/Transaction'
import {
  TransactionEnum,
  TransactionMapping,
} from 'src/app/models/TransactionEnum'
import { TransactionService } from 'src/app/services/transaction.service'

@Component({
  selector: 'app-transaction-edit',
  templateUrl: './transaction-edit.component.html',
})
export class TransactionEditComponent implements OnInit {
  form: UntypedFormGroup
  types: (string | TransactionEnum)[]
  transactionMapping = TransactionMapping
  members: Member[]
  transaction: Transaction

  get isDescriptionInvalid(): boolean {
    return this.hasErros('description')
  }

  get controls(): { [key: string]: AbstractControl } {
    return this.form.controls
  }

  constructor(
    private _transactioService: TransactionService,
    private _formBuilder: UntypedFormBuilder,
    private _router: Router,
    private _route: ActivatedRoute,
    private _spinner: NgxSpinnerService,
    private _toasterService: ToastrService,
    private _modalService: NgbModal,
  ) {
    this.members = []
    this.types = Object.values(TransactionEnum).filter(
      (value) => typeof value === 'number',
    )
    this.transaction = new Transaction()
    this.form = this._formBuilder.group({
      date: [''],
      amount: [''],
      type: [''],
      description: [''],
      responsable: [''],
    })
    this.controls.date.disable()
    this.controls.amount.disable()
    this.controls.type.disable()
    this.controls.responsable.disable()
  }

  ngOnInit(): void {
    this._spinner.show()
    let observer = {
      next: (response: Transaction) => {
        this.transaction = Object.assign(new Transaction(), response)
        this.form.patchValue({ id: this.transaction.id })
        this.form.patchValue({ date: this.transaction.dateStr })
        this.form.patchValue({ amount: this.transaction.amountStr })
        this.form.patchValue({ type: this.transaction.type })
        this.form.patchValue({ description: this.transaction.description })
        this.form.patchValue({
          responsable: this.transaction.responsable?.name,
        })
      },
      error: (error: any) => {
        this._toasterService.error(
          'Algo deu errado 😵. Tente novamente mais tarde.',
          'Erro',
        )
        console.error('Erro:' + error.statusText)
      },
    }

    this._route.params.subscribe((params) => {
      let id = params['id']
      this._transactioService
        .read(id)
        .pipe(finalize(() => this._spinner.hide()))
        .subscribe(observer)
    })
  }

  onSave() {
    this._spinner.show()
    this.transaction.description = this.controls.description.value
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
      .edit(this.transaction)
      .pipe(finalize(() => this._spinner.hide()))
      .subscribe(observer)
  }

  onCancel() {
    this._router.navigate(['transaction']);
  }

  private hasErros(field: string): boolean {
    const hasErros =
      this.form.get(field)?.errors &&
      (this.form.get(field)?.dirty || this.form.get(field)?.touched)
    return Boolean(hasErros)
  }
}
