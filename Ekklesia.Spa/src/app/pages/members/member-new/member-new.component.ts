import { Component } from '@angular/core'
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms'
import { Router } from '@angular/router'

import { MASKS, NgBrazilValidators } from 'ng-brazil'

import { UtilsValidators } from 'src/app/utils/utils-validators'

import { Member } from 'src/app/models/Member'
import { RoleEnum, RoleMapping } from 'src/app/models/RoleEnum'
import { MemberService } from 'src/app/services/member.service'
import { ToastrService } from 'ngx-toastr'
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'
import { CustomModalComponent } from 'src/app/components/custom-modal/custom-modal.component'
import { NgxSpinnerService } from 'ngx-spinner'
import { finalize } from 'rxjs'

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
    private _toasterService: ToastrService,
    private _modalService: NgbModal,
    private _spinner: NgxSpinnerService,
  ) {
    this.roles = Object.values(RoleEnum).filter(
      (value) => typeof value === 'number',
    )

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
      role: ['', [Validators.required]],
    })
  }

  private hasErros(field: string): boolean {
    const hasErros =
      this.form.get(field)?.errors &&
      (this.form.get(field)?.dirty || this.form.get(field)?.touched)
    return Boolean(hasErros)
  }

  public onSave(): void {
    this._spinner.show()
    const member: Member = Object.assign(new Member(), this.form.value)
    member.phone = member.phone.replace(/\D/g, '')
    const observer = {
      next: (x: Member) => {
        this._toasterService.success(
          `Membro ${x.name} adicionado!`,
          'Sucesso ✌️',
        )
        this._router.navigate(['member'])
      },
      error: (error: any) => {
        this._toasterService.error(
          'Algo deu errado 😵. Tente novamente mais tarde.',
          'Erro',
        )
        console.error('Erro:' + error.statusText)
      },
    }
    this._memberService
      .add(member)
      .pipe(finalize(() => this._spinner.hide()))
      .subscribe(observer)
  }

  public onCancel(): void {
    if (this.form.dirty) {
      const modalRef = this._modalService.open(CustomModalComponent)
      modalRef.componentInstance.title = 'Deseja sair?'
      modalRef.componentInstance.message =
        'As alterações não salvas em membros serão perdidas'
      modalRef.result.then(
        (res) => {
          this.form = this._formBuilder.group({})
          this._router.navigate(['member'])
        },
        (dismiss) => {},
      )
    } else {
      this._router.navigate(['member'])
    }
  }
}
