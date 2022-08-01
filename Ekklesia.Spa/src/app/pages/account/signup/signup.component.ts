import { Component, OnInit } from '@angular/core'
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms'
import { Router } from '@angular/router'
import { MASKS, NgBrazilValidators } from 'ng-brazil'
import { CustomValidators } from 'ng2-validation'
import { Account } from 'src/app/models/Account'
import { SignUp } from 'src/app/models/SignUp'
import { IdentityService } from 'src/app/services/identity.service'
import { UtilsValidators } from 'src/app/utils/utils-validators'

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
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

  get controls(): { [key: string]: AbstractControl } {
    return this.form.controls
  }

  constructor(
    private _formBuilder: FormBuilder,
    private _accountService: IdentityService,
    private _router: Router,
  ) {
    const password = new FormControl('', [
      Validators.required,
      Validators.minLength(8),
      Validators.maxLength(16),
      UtilsValidators.withLowerCase,
      UtilsValidators.withUpperCase,
      UtilsValidators.withNumbers,
      UtilsValidators.withSpecialCharacter,
    ])

    const passwordConfirmation = new FormControl('', [
      Validators.required,
      CustomValidators.equalTo(password),
    ])
    this.form = this._formBuilder.group({
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(50),
          UtilsValidators.withLowerCase,
          UtilsValidators.withUpperCase,
          UtilsValidators.withoutNumbers,
          UtilsValidators.withoutSpecialCharacter,
        ],
      ],
      phone: ['', [Validators.required, NgBrazilValidators.telefone]],
      email: ['', [Validators.email, Validators.required]],
      password: password,
      passwordConfirmation: passwordConfirmation,
      remember: ['', [Validators.required]],
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
    return
    let account = Object.assign(new SignUp(), this.form.value)
    const observer = {
      next: (x: Response) => this._router.navigate(['member']),
      error: (err: any) => console.error(err.error),
    }
    this._accountService.signup(account).subscribe(observer)
  }
}
