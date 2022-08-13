import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { CustomMenuComponent } from './custom-menu/custom-menu.component'
import { CustomFooterComponent } from './custom-footer/custom-footer.component'
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome'
import { NgbCollapseModule, NgbModule } from '@ng-bootstrap/ng-bootstrap'
import { RouterModule } from '@angular/router'
import { CustomProfileComponent } from './custom-menu/custom-profile/custom-profile.component'

@NgModule({
  declarations: [
    CustomMenuComponent,
    CustomFooterComponent,
    CustomProfileComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FontAwesomeModule,
    NgbModule,
    NgbCollapseModule,
  ],
  exports: [CustomFooterComponent, CustomMenuComponent],
})
export class CustomNavigationModule {}
