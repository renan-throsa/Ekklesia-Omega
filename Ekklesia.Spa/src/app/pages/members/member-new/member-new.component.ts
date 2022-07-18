import { Component } from '@angular/core'
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms'
import { Router } from '@angular/router'
import { MASKS, NgBrazilValidators } from 'ng-brazil'
import { Member } from 'src/app/models/Member'
import { RoleEnum, RoleMapping } from 'src/app/models/RoleEnum'
import { MemberService } from 'src/app/services/member.service'

@Component({
  selector: 'app-member-new',
  templateUrl: './member-new.component.html',
})
export class MemberNewComponent {
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

  get controls(): { [key: string]: AbstractControl } {
    return this.form.controls
  }

  constructor(
    private _formBuilder: FormBuilder,
    private _memberService: MemberService,
    private _router: Router,
  ) {
    this.roles = Object.values(RoleEnum).filter(
      (value) => typeof value === 'number',
    )

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
    this._memberService.add(member).subscribe(observer)
  }

  onCancel() {
    this._router.navigate(['/member'])
  }
}
