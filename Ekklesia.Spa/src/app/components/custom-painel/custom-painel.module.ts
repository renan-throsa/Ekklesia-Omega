import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { CustomPainelComponent } from './custom-painel.component'
import { RouterModule } from '@angular/router'

@NgModule({
  declarations: [CustomPainelComponent],
  imports: [CommonModule, RouterModule],
  exports: [CustomPainelComponent],
})
export class CustomPainelModule {}
