import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
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
  },
  {
    path: 'new',
    component: MemberNewComponent,
  },
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MemberRoutingModule {}
