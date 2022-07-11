import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { CustomPainelComponent } from './custom-painel.component'

@NgModule({
  declarations: [CustomPainelComponent],
  imports: [CommonModule],
  exports: [CustomPainelComponent],
})
export class CustomPainelModule {}
