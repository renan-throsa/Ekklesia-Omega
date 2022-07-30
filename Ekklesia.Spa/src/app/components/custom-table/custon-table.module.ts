import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { CustonTableComponent } from './custon-table.component'
import { RouterModule } from '@angular/router'

@NgModule({
  declarations: [CustonTableComponent],
  imports: [CommonModule, RouterModule],
  exports: [CustonTableComponent],
})
export class CustonTableModule {}
