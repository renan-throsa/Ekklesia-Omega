import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { CustomMenuComponent } from './custom-menu/custom-menu.component'
import { CustomFooterComponent } from './custom-footer/custom-footer.component'
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome'
import { NgbModule } from '@ng-bootstrap/ng-bootstrap'

@NgModule({
  declarations: [CustomMenuComponent, CustomFooterComponent],
  imports: [CommonModule, FontAwesomeModule,NgbModule],
  exports: [CustomFooterComponent, CustomMenuComponent],
})
export class CustomNavigationModule {}
