import { Component, OnInit } from '@angular/core'
import { BaseTable } from 'src/app/components/Shared/BaseTable'
import { Transaction } from 'src/app/models/Transaction'

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html',
})
export class TransactionListComponent extends BaseTable<Transaction> {
  constructor() {
    super()
    this.columns = [
      {
        name: 'Nome',
        field: 'name',
      },
      {
        name: 'Telefone',
        field: 'phone',
      },
      {
        name: 'Cargo',
        field: 'role',
      },
    ]
  }
}
