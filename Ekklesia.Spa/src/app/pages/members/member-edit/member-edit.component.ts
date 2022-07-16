import { Component, OnInit } from '@angular/core'
import { ActivatedRoute, Router } from '@angular/router'
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms'

import { MASKS, NgBrazilValidators } from 'ng-brazil'

import { Member } from 'src/app/models/Member'

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
})
export class MemberEditComponent implements OnInit {
  member: Member
  form: FormGroup
  MASKS = MASKS

  get isNameInvalid(): boolean {
    return this.hasErros('name')
  }

  get isPhoneInvalid(): boolean {
    return this.hasErros('phone')
  }

  get isformInvalid(): boolean {
    return !this.form.dirty && !this.form.valid
  }

  get controls(): { [key: string]: AbstractControl } {
    return this.form.controls
  }

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private _formBuilder: FormBuilder,
  ) {
    this.member = new Member()
    this.form = this._formBuilder.group({
      name: [
        '',
        [
          Validators.required,
          Validators.pattern(
            /^[A-ZÀ-Ÿ][A-zÀ-ÿ']+\s([A-zÀ-ÿ']\s?)*[A-ZÀ-Ÿ][A-zÀ-ÿ']+$/,
          ),
        ],
      ],
      phone: ['', [Validators.required, NgBrazilValidators.telefone]],
      role: ['', [Validators.required]],
    })
  }
  ngOnInit(): void {
    this._route.params.subscribe((params) => {
      console.log(params['id'])
    })
  }

  private hasErros(field: string): boolean {
    const hasErros =
      this.form.get(field)?.errors &&
      (this.form.get(field)?.dirty || this.form.get(field)?.touched)
    return Boolean(hasErros)
  }

  save() {
    console.log(this.form.value)
    const account = Object.assign(new Member(), this.form.value)
    console.log(account)
  }

  cancel() {
    this._router.navigate(['member'])
  }
}
