import { Component } from '@angular/core'
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms'
import { NgBrazilValidators } from 'ng-brazil'

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
})
export class SigninComponent {
  form: FormGroup

  get isNameInvalid(): boolean {
    return this.hasErros('name')
  }

  get isPhoneInvalid(): boolean {
    return this.hasErros('phone')
  }

  get isEmailInvalid(): boolean {
    return this.hasErros('email')
  }

  get isPasswordInvalid(): boolean {
    return this.hasErros('password')
  }

  get isformInvalid(): boolean {
    return !this.form.dirty && !this.form.valid
  }

  get controls(): { [key: string]: AbstractControl } {
    return this.form.controls
  }

  constructor(private _formBuilder: FormBuilder) {
    this.form = this._formBuilder.group({
      name: [
        '',
        Validators.required,
        Validators.pattern(
          /^[A-ZÀ-Ÿ][A-zÀ-ÿ']+\s([A-zÀ-ÿ']\s?)*[A-ZÀ-Ÿ][A-zÀ-ÿ']+$/g,
        ),
      ],
      phone: ['', Validators.required, NgBrazilValidators.telefone],
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
      remember: ['', Validators.required],
    })
  }

  signin() {
    console.log('Teste de sign in.')
  }

  private hasErros(field: string): boolean {
    const hasErros =
      this.form.get(field)?.errors &&
      (this.form.get(field)?.dirty || this.form.get(field)?.touched)
    return Boolean(hasErros)
  }
}
