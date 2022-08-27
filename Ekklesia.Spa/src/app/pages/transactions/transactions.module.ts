import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { TransactionListComponent } from './transaction-list/transaction-list.component'
import { TransactionNewComponent } from './transaction-new/transaction-new.component'
import { TransactionEditComponent } from './transaction-edit/transaction-edit.component'
import { TransactionSearchComponent } from './transaction-search/transaction-search.component'
import { TransactionRoutingModule } from './transaction-routing.module'
import { CustonTableModule } from 'src/app/components/custom-table/custon-table.module'
import { CustomPainelModule } from 'src/app/components/custom-search/custom-painel.module'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { NgBrazil } from 'ng-brazil'
import { CustomFormsModule } from 'ng2-validation'

@NgModule({
  declarations: [
    TransactionListComponent,
    TransactionNewComponent,
    TransactionEditComponent,
    TransactionSearchComponent,
  ],
  exports: [
    TransactionListComponent,
    TransactionNewComponent,
    TransactionEditComponent,
    TransactionSearchComponent,
  ],
  imports: [
    CommonModule,
    TransactionRoutingModule,
    CustonTableModule,
    CustomPainelModule,
    FormsModule,
    ReactiveFormsModule,
    NgBrazil,
    CustomFormsModule,
  ],
})
export class TransactionsModule {}
