import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { SigninComponent } from './signin/signin.component'
import { SignupComponent } from './signup/signup.component'
import { AccountRoutingModule } from './account-routing.module'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { NgBrazil } from 'ng-brazil'
import { TextMaskModule } from 'angular2-text-mask'
import { ProfileComponent } from './profile/profile.component'
import { CustomFormsModule } from 'ng2-validation'

@NgModule({
  declarations: [SigninComponent, SignupComponent, ProfileComponent],
  imports: [
    CommonModule,
    AccountRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgBrazil,
    TextMaskModule,
    CustomFormsModule,
  ],
  exports: [SigninComponent, SignupComponent, ProfileComponent],
})
export class AccountModule {}
