import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { InputGuard } from 'src/app/services/input.guard'
import { MemberEditComponent } from './member-edit/member-edit.component'
import { MemberListComponent } from './member-list/member-list.component'
import { MemberNewComponent } from './member-new/member-new.component'

const routes: Routes = [
  {
    path: '',
    component: MemberListComponent,
  },
  {
    path: 'edit/:id',
    component: MemberEditComponent,
    canDeactivate: [InputGuard],
  },
  {
    path: 'new',
    component: MemberNewComponent,
    canDeactivate: [InputGuard],
  },
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MemberRoutingModule {}
