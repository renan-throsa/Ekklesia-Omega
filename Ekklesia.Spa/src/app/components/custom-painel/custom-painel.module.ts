import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { CustomPainelComponent } from './custom-painel.component'
import { RouterModule } from '@angular/router'
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome'

@NgModule({
  declarations: [CustomPainelComponent],
  imports: [CommonModule, RouterModule,FontAwesomeModule],
  exports: [CustomPainelComponent],
})
export class CustomPainelModule {}
