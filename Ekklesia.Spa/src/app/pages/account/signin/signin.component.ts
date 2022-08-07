import { Component } from '@angular/core'
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
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
  form: FormGroup

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
    private _formBuilder: FormBuilder,
    private _accountService: IdentityService,
    private _router: Router,
    private _toasterService: ToastrService,
  ) {
    this.form = this._formBuilder.group({
      email: ['', [Validators.email, Validators.required]],
      password: [
        '',
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
      next: (x: any) => {
        this._accountService.saveUserDataLocaly(x)
        this._toasterService.success(
          `Seja bem bindo, ${this._accountService.getUser()?.name}!`,
          'Sucesso ✌️',
        )
        this._router.navigate(['member'])
      },
      error: (err: any) => {
        this._toasterService.error(
          'Algo deu errado 😵. Tente novamente mais tarde.',
          'Erro',
        )
        console.error(err.error)
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
