import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { MemberListComponent } from './member-list/member-list.component'
import { MemberSearchComponent } from './member-search/member-search.component'
import { MemberNewComponent } from './member-new/member-new.component'
import { MemberEditComponent } from './member-edit/member-edit.component'
import { MemberRoutingModule } from './member-routing.module'
import { CustonTableModule } from 'src/app/components/custon-table/custon-table.module'
import { CustomPainelModule } from 'src/app/components/custom-painel/custom-painel.module'

@NgModule({
  declarations: [
    MemberListComponent,
    MemberSearchComponent,
    MemberNewComponent,
    MemberEditComponent,
  ],
  imports: [CommonModule, MemberRoutingModule, CustonTableModule,CustomPainelModule],
  exports: [
    MemberListComponent,
    MemberSearchComponent,
    MemberNewComponent,
    MemberEditComponent,
  ],
})
export class MembersModule {}
