import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { CustomPainelComponent } from './custom-painel.component'
import { RouterModule } from '@angular/router'
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome'
import { ReactiveFormsModule } from '@angular/forms'

@NgModule({
  declarations: [CustomPainelComponent],
  imports: [CommonModule,ReactiveFormsModule , RouterModule,FontAwesomeModule],
  exports: [CustomPainelComponent],
})
export class CustomPainelModule {}
