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
import { MemberService } from 'src/app/services/member.service'
import { RoleEnum, RoleMapping } from 'src/app/models/RoleEnum'

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
})
export class MemberEditComponent implements OnInit {
  form: FormGroup
  roles: (string | RoleEnum)[]
  roleapping = RoleMapping
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
    private _memberService: MemberService,
  ) {
    this.roles = Object.values(RoleEnum).filter(
      (value) => typeof value === 'number',
    )
    this.form = this._formBuilder.group({
      id: ['', [Validators.required]],
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
    let observer = {
      next: (response: Member) => {
        this.form.patchValue({ id: response.id })
        this.form.patchValue({ name: response.name })
        this.form.patchValue({ phone: response.phone })
        this.form.patchValue({ photo: response.photo })
        this.form.patchValue({ role: response.role })
      },
      error: (error: any) =>
        console.error('Não foi possível obter o membro: ' + error),
    }

    this._route.params.subscribe((params) => {
      let id = params['id']
      this._memberService.read(id).subscribe(observer)
    })
  }

  private hasErros(field: string): boolean {
    const hasErros =
      this.form.get(field)?.errors &&
      (this.form.get(field)?.dirty || this.form.get(field)?.touched)
    return Boolean(hasErros)
  }

  onSave() {
    const member: Member = Object.assign(new Member(), this.form.value)
    member.phone = member.phone.replace(/\D/g, '')
    const observer = {
      next: (x: Response) => this._router.navigate(['member']),
      error: (err: any) => console.error('Observer got an error: ' + err),
    }
    this._memberService.edit(member).subscribe(observer)
  }

  onCancel() {
    this._router.navigate(['member'])
  }
}
