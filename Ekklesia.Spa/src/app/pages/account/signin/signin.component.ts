import { Component } from '@angular/core'
import {
  AbstractControl,
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from '@angular/forms'
import { Router } from '@angular/router'

import { ToastrService } from 'ngx-toastr'

import { SignIn } from 'src/app/models/SignIn'
import { IdentityService } from 'src/app/services/identity.service'

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
})
export class SigninComponent {
  form: UntypedFormGroup

  get isEmailInvalid(): boolean {
    return this._hasErros('email')
  }

  get isPasswordInvalid(): boolean {
    return this._hasErros('password')
  }

  get controls(): { [key: string]: AbstractControl } {
    return this.form.controls
  }

  constructor(
    private _formBuilder: UntypedFormBuilder,
    private _accountService: IdentityService,
    private _router: Router,
    private _toasterService: ToastrService,
  ) {
    this.form = this._formBuilder.group({
      email: ['renan@email.com', [Validators.email, Validators.required]],
      password: [
        'D1stroi@',
        [
          Validators.required,
          Validators.pattern(
            /^((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{6,20})$/,
          ),
        ],
      ],
      remember: [''],
    })
  }

  signin() {
    let account = Object.assign(new SignIn(), this.form.value)
    const observer = {
      next: (token: string) => {        
        this._accountService.authenticate(token)
        this._toasterService.success(
          `Seja bem vindo, ${this._accountService.User.name}!`,
          'Sucesso ✌️',
        )
        this._router.navigate(['member'])
      },
     
    }
    this._accountService.signIn(account).subscribe(observer)
  }

  private _hasErros(field: string): boolean {
    const hasErros =
      this.form.get(field)?.errors &&
      (this.form.get(field)?.dirty || this.form.get(field)?.touched)
    return Boolean(hasErros)
  }
}
