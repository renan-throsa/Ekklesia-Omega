import { Component, OnInit } from '@angular/core'
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router'
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
  form: FormGroup
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
    private _formBuilder: FormBuilder,
    private _router: Router,
    private _route: ActivatedRoute,
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
      error: (error: any) =>
        console.error('Não foi possível obter a transação: ' + error),
    }

    this._route.params.subscribe((params) => {
      let id = params['id']
      this._transactioService.read(id).subscribe(observer)
    })
  }

  onSave() {
    this.transaction.description = this.controls.description.value    
    const observer = {
      next: (x: Response) => this._router.navigate(['transaction']),
      error: (err: any) => console.error('Observer got an error: ' + err),
    }
    this._transactioService.edit(this.transaction).subscribe(observer)
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
