import { Component, OnInit } from '@angular/core'
import { NgxSpinnerService } from 'ngx-spinner'
import { BaseTable } from 'src/app/components/shared/base-table'
import { Transaction } from 'src/app/models/Transaction'
import { TransactionService } from 'src/app/services/transaction.service'
import { finalize } from 'rxjs'
import { ToastrService } from 'ngx-toastr'

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
})
export class TransactionListComponent extends BaseTable<Transaction>
  implements OnInit {
  transactions: Transaction[]

  constructor(
    private _transactioService: TransactionService,
    private _spinner: NgxSpinnerService,
    private _toasterService: ToastrService,
  ) {
    super()
    this.transactions = []
    this.columns = [
      {
        name: 'Data',
        field: 'dateStr',
      },
      {
        name: 'Valor',
        field: 'amountStr',
      },
      {
        name: 'Tipo',
        field: 'typeName',
      },
      {
        name: 'Responsável',
        field: 'responsable.name',
      },
    ]
  }

  ngOnInit(): void {
    this._spinner.show()
    const observer = {
      next: (result: Transaction[]) => {
        this.transactions = result.map((x) =>
          Object.assign(new Transaction(), x),
        )
      },
      error: (error: any) => {
        this._toasterService.error(
          'Algo deu errado 😵. Tente novamente mais tarde.',
          'Erro',
        )
        console.error('Erro:' + error.statusText)
      },
    }

    this._transactioService
      .browse()
      .pipe(finalize(() => this._spinner.hide()))
      .subscribe(observer)
  }
}
