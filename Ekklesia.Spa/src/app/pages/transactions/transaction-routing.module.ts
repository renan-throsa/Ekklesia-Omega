import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { TransactionEditComponent } from './transaction-edit/transaction-edit.component'
import { TransactionListComponent } from './transaction-list/transaction-list.component'
import { TransactionNewComponent } from './transaction-new/transaction-new.component'

const routes: Routes = [
  {
    path: '',
    component: TransactionListComponent,
  },
  {
    path: 'edit/:id',
    component: TransactionEditComponent,
  },
  {
    path: 'new',
    component: TransactionNewComponent,
  },
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TransactionRoutingModule {}
