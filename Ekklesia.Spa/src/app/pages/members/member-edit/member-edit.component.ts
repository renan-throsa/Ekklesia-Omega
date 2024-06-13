import { Component, OnInit } from '@angular/core'
import { ActivatedRoute, Router } from '@angular/router'
import {
  AbstractControl,
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from '@angular/forms'

import { MASKS, NgBrazilValidators } from 'ng-brazil'
import { UtilsValidators } from 'src/app/utils/utils-validators'
import { ToastrService } from 'ngx-toastr'
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'

import { Member } from 'src/app/models/Member'
import { MemberService } from 'src/app/services/member.service'
import { RoleEnum, RoleMapping } from 'src/app/models/RoleEnum'
import { CustomModalComponent } from 'src/app/components/custom-modal/custom-modal.component'
import { NgxSpinnerService } from 'ngx-spinner'
import { finalize } from 'rxjs'

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
})
export class MemberEditComponent implements OnInit {
  form: UntypedFormGroup
  roles: (string | RoleEnum)[]
  roleapping = RoleMapping
  MASKS = MASKS

  get isNameInvalid(): boolean {
    return this._hasErros('name')
  }

  get isPhoneInvalid(): boolean {
    return this._hasErros('phone')
  }

  get controls(): { [key: string]: AbstractControl } {
    return this.form.controls
  }

  get isInvalid() {
    return !(this.form.dirty && this.form.valid)
  }

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private _formBuilder: UntypedFormBuilder,
    private _memberService: MemberService,
    private _toasterService: ToastrService,
    private _modalService: NgbModal,
    private _spinner: NgxSpinnerService,
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
          Validators.minLength(5),
          Validators.maxLength(50),
          UtilsValidators.withLowerCase,
          UtilsValidators.withUpperCase,
          UtilsValidators.withoutNumbers,
          UtilsValidators.withoutSpecialCharacter,
        ],
      ],
      phone: ['', [Validators.required, NgBrazilValidators.telefone]],
      role: ['', [Validators.required]],
    })
  }
  ngOnInit(): void {
    this._spinner.show()
    let observer = {
      next: (response: Member) => {
        this.form.patchValue({ id: response.id })
        this.form.patchValue({ name: response.name })
        this.form.patchValue({ phone: response.phone })
        this.form.patchValue({ photo: response.photo })
        this.form.patchValue({ role: response.role })
      },
      error: (err: any) => {
        this._toasterService.error(
          'Algo deu errado 😵. Tente novamente mais tarde.',
          'Erro',
          { closeButton: true, progressBar: true },
        )
        console.error(err.error.payload)
      },
    }

    this._route.params.subscribe((params) => {
      let id = params['id']
      this._memberService
        .read(id)
        .pipe(finalize(() => this._spinner.hide()))
        .subscribe(observer)
    })
  }

  private _hasErros(field: string): boolean {
    const hasErros =
      this.form.get(field)?.errors &&
      (this.form.get(field)?.dirty || this.form.get(field)?.touched)
    return Boolean(hasErros)
  }

  public onSave(): void {
    const member: Member = Object.assign(new Member(), this.form.value)
    member.phone = member.phone.replace(/\D/g, '')

    const observer = {
      next: (x: Member) => {
        this._toasterService.success(`Membro ${x.name} editado!`, 'Sucesso ✌️');
        this.form.markAsPristine();
        this._router.navigate(['member']);
      },
      error: (error: any) => {
        this._toasterService.error(
          'Algo deu errado 😵. Tente novamente mais tarde.',
          'Erro',
        )
        console.error('Erro:' + error.statusText)
      },
    }

    this._memberService.edit(member).subscribe(observer)
  }

  public onCancel(): void {
    this._router.navigate(['member']);
  }
}
