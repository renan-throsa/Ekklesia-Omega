import { Component, OnInit } from '@angular/core'
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router'
import { NgxSpinnerService } from 'ngx-spinner'
import { ToastrService } from 'ngx-toastr'
import { finalize, map } from 'rxjs'
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
  styles: [`
    .card-footer > button + button {
      margin-left: 1%;
    }
  `]
})
export class TransactionEditComponent implements OnInit {
  form: UntypedFormGroup;
  types: (string | TransactionEnum)[];
  transactionMapping = TransactionMapping;
  members: Member[];
  imageBase64!: string;
  private readonly _reader: FileReader;

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
  ) {
    this._reader = new FileReader();
    this._reader.onload = (e: any) => {
      this.imageBase64 = `data:image/png;base64,${e.target.result.split(',')[1]}`;
    };

    this.members = []
    this.types = Object.values(TransactionEnum).filter(
      (value) => typeof value === 'number',
    )

    this.form = this._formBuilder.group({
      id: ['', [Validators.required]],
      date: [{ value: '', disabled: true }],
      amount: [{ value: '', disabled: true }],
      type: [{ value: '', disabled: true }],
      responsable: [{ value: '', disabled: true }],
      description: [{ value: '', }],
      formFile: [null]
    });

  }

  ngOnInit(): void {
    this._spinner.show()
    let observer = {
      next: (transaction: Transaction) => {
        this.form.patchValue({ id: transaction.id })
        this.form.patchValue({ date: transaction.dateStr })
        this.form.patchValue({ amount: transaction.amount })
        this.form.patchValue({ type: transaction.type })
        this.form.patchValue({ description: transaction.description })
        this.form.patchValue({
          responsable: transaction.responsable,
        });

        this.imageBase64 = transaction.receipt;

        if (transaction.responsable) {
          this.members.push(transaction.responsable);
        }
      },

      error: (error: any) => {
        this._toasterService.error(
          'Algo deu errado 😵. Tente novamente mais tarde.',
          'Erro',
        )
        console.error('Erro:' + error.statusText);
      },
    }

    this._route.params.subscribe((params) => {
      let id = params['id']
      this._transactioService
        .read(id)
        .pipe(map(response => Object.assign(new Transaction(), response)), finalize(() => this._spinner.hide()))
        .subscribe(observer)
    });
  }

  onSave() {
    this._spinner.show();
    const transaction: Transaction = Object.assign(new Transaction(), this.form.getRawValue());

    const observer = {
      next: (x: Response) => { 
        this._toasterService.success(
          `Transação editada!`,
          'Sucesso ✌️',
        )
        this.form.markAsPristine(); this._router.navigate(['transaction']); },
      error: (error: any) => {
        this._toasterService.error(
          'Algo deu errado 😵. Tente novamente mais tarde.',
          'Erro',
        )
        console.error('Erro:' + error.statusText)
      },
    }
    this._transactioService
      .edit(transaction)
      .pipe(finalize(() => this._spinner.hide()))
      .subscribe(observer)
  }

  public onCancel(): void {
    this._router.navigate(['transaction']);
  }

  private hasErros(field: string): boolean {
    const hasErros =
      this.form.get(field)?.errors &&
      (this.form.get(field)?.dirty || this.form.get(field)?.touched)
    return Boolean(hasErros)
  }

  public imagePicked(event: any): void {
    const file: File = event.target.files[0];
    const muiltiplier = 2;
    const oneMegaByte = 1048576;
    const allowedSize = muiltiplier * oneMegaByte;

    if (file.size > allowedSize) {
      this._toasterService.warning(`O tamanho máximo do arquivo permitido é de ${muiltiplier}MB`, 'Tamanho máximo excedido');
      return;
    }

    this._reader.readAsDataURL(file);
    this.form.patchValue({ formFile: file });
    this.form.markAsDirty();
  }
}
