import { Component, OnInit } from '@angular/core'
import { BaseTable } from 'src/app/components/shared/base-table'
import { Transaction } from 'src/app/models/Transaction'
import { TransactionService } from 'src/app/services/transaction.service'

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
})
export class TransactionListComponent extends BaseTable<Transaction>
  implements OnInit {
  transactions: Transaction[]

  constructor(private _transactioService: TransactionService) {
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
    this._transactioService.browse().subscribe((result: Transaction[]) => {
      this.transactions = result.map((x) => Object.assign(new Transaction(), x))
    })
  }
}
