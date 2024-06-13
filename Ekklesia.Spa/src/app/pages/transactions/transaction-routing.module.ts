import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { TransactionEditComponent } from './transaction-edit/transaction-edit.component'
import { TransactionListComponent } from './transaction-list/transaction-list.component'
import { TransactionNewComponent } from './transaction-new/transaction-new.component'
import { InputGuard } from 'src/app/services/input.guard'

const routes: Routes = [
  {
    path: '',
    component: TransactionListComponent,
  },
  {
    path: 'edit/:id',
    component: TransactionEditComponent,    
    canDeactivate: [InputGuard],
  },
  {
    path: 'new',
    component: TransactionNewComponent,
    canDeactivate: [InputGuard],
  },
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TransactionRoutingModule {}
