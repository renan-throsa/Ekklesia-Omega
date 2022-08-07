import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { AuthGard } from './services/auth.guard'

const routes: Routes = [
  {
    path: '',
    redirectTo: '/member',
    pathMatch: 'full',
  },
  {
    path: 'member',
    loadChildren: () =>
      import('./pages/members/members.module').then((m) => m.MembersModule),
    canLoad: [AuthGard],
  },
  {
    path: 'transaction',
    loadChildren: () =>
      import('./pages/transactions/transactions.module').then(
        (m) => m.TransactionsModule,
      ),
      canLoad: [AuthGard]
  },
  {
    path: 'account',
    loadChildren: () =>
      import('./pages/account/account.module').then((m) => m.AccountModule),
  },
  {
    path: '**',
    loadChildren: () =>
      import('./pages/error/error.pages.module').then(
        (m) => m.ErrorPagesModule,
      ),
  },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
