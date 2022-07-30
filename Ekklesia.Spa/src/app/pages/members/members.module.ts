import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { MemberListComponent } from './member-list/member-list.component'
import { MemberSearchComponent } from './member-search/member-search.component'
import { MemberNewComponent } from './member-new/member-new.component'
import { MemberEditComponent } from './member-edit/member-edit.component'
import { MemberRoutingModule } from './member-routing.module'
import { CustonTableModule } from 'src/app/components/custom-table/custon-table.module'
import { CustomPainelModule } from 'src/app/components/custom-painel/custom-painel.module'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { NgBrazil } from 'ng-brazil'
import { TextMaskModule } from 'angular2-text-mask'
import { CustomFormsModule } from 'ng2-validation'

@NgModule({
  declarations: [
    MemberListComponent,
    MemberSearchComponent,
    MemberNewComponent,
    MemberEditComponent,
  ],
  imports: [
    CommonModule,
    MemberRoutingModule,
    CustonTableModule,
    CustomPainelModule,
    FormsModule,
    ReactiveFormsModule,
    NgBrazil,
    TextMaskModule,
    CustomFormsModule,
  ],
  exports: [
    MemberListComponent,
    MemberSearchComponent,
    MemberNewComponent,
    MemberEditComponent,
  ],
})
export class MembersModule {}
