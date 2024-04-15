import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { CustonTableComponent } from './custon-table.component'
import { RouterModule } from '@angular/router'
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome'

@NgModule({
  declarations: [CustonTableComponent],
  imports: [CommonModule, RouterModule, FontAwesomeModule],
  exports: [CustonTableComponent],
})
export class CustonTableModule {}
