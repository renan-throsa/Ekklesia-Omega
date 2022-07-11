import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { HomeComponent } from './pages/home/home.component'

const routes: Routes = [
  {
    path: '',
    redirectTo: '/member',
    pathMatch: 'full',
  },
  {
    path: 'member',
    loadChildren: () =>
      import('./pages/members/members.module').then((m) => m.MembersModule)
  },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
