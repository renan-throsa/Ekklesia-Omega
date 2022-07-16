import { Component, OnInit } from '@angular/core'
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms'
import { MASKS, NgBrazilValidators } from 'ng-brazil'
import { CustomValidators } from 'ng2-validation'
import { Account } from 'src/app/models/Account'

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html'
})
export class SignupComponent implements OnInit {
  form: FormGroup
  MASKS = MASKS

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
    const password = new FormControl('', [
      Validators.required,
      Validators.pattern(/^((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{6,20})$/),
    ])

    const passwordConfirmation = new FormControl('', [
      Validators.required,
      CustomValidators.equalTo(password),
    ])
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
      password: password,
      passwordConfirmation: passwordConfirmation,
      remember: ['', Validators.required],
    })
  }

  ngOnInit(): void {}

  private hasErros(field: string): boolean {
    const hasErros =
      this.form.get(field)?.errors &&
      (this.form.get(field)?.dirty || this.form.get(field)?.touched)
    return Boolean(hasErros)
  }

  signup() {
    console.log(this.form.value)
    const account = Object.assign(new Account(), this.form.value)
    console.log(account)
  }
}
