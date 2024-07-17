import { Component } from '@angular/core'
import {
  AbstractControl,
  FormGroup,
  UntypedFormBuilder,
  Validators,
} from '@angular/forms'
import { Router } from '@angular/router'

import { MASKS, NgBrazilValidators } from 'ng-brazil'

import { UtilsValidators } from 'src/app/utils/utils-validators'

import { Member } from 'src/app/models/Member'
import { RoleEnum, RoleMapping } from 'src/app/models/RoleEnum'
import { MemberService } from 'src/app/services/member.service'
import { ToastrService } from 'ngx-toastr'
import { NgxSpinnerService } from 'ngx-spinner'
import { finalize } from 'rxjs'

@Component({
  selector: 'app-member-new',  
  templateUrl: './member-new.component.html',
  styles: [`
    .card-footer > button + button {
      margin-left: 1%;
    }
  `]
  
})
export class MemberNewComponent {
  form: FormGroup
  roles: (string | RoleEnum)[]
  roleapping = RoleMapping
  MASKS = MASKS
  imageUrl!: string | ArrayBuffer;

  maxDate: Date

  private readonly _reader: FileReader;

  get isNameInvalid(): boolean {
    return this._hasErros('name')
  }

  get isPhoneInvalid(): boolean {
    return this._hasErros('phone')
  }

  get isDateInvalid(): boolean {
    return this._hasErros('birthDay')
  }

  get controls(): { [key: string]: AbstractControl } {
    return this.form.controls
  }




  constructor(
    private _formBuilder: UntypedFormBuilder,
    private _memberService: MemberService,
    private _router: Router,
    private _toasterService: ToastrService,
    private _spinner: NgxSpinnerService,
  ) {

    this.maxDate = new Date();

    this._reader = new FileReader();
    this._reader.onload = (e: any) => { this.imageUrl = e.target.result; };

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
      birthDay: ['', [Validators.required, UtilsValidators.maxDate(this.maxDate)]],
      formFile: [null]
    })
  }

  private _hasErros(field: string): boolean {
    const hasErros =
      this.form.get(field)?.errors &&
      (this.form.get(field)?.dirty || this.form.get(field)?.touched)
    return Boolean(hasErros)
  }

  public onSave(): void {
    this._spinner.show()
    const member: Member = Object.assign(new Member(), this.form.value)
    member.phone = member.phone.replace(/\D/g, '');

    const observer = {
      next: (x: Member) => {
        this._toasterService.success(
          `Membro ${x.name} adicionado!`,
          'Sucesso ✌️',
        )
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
    this._memberService
      .add(member)
      .pipe(finalize(() => this._spinner.hide()))
      .subscribe(observer)
  }

  public onCancel(): void {
    this._router.navigate(['member'])
  }

  public imagePicked(event: any): void {
    const file: File = event.target.files[0];
    const muiltiplier = 2;
    const oneMegaByte = 1048576;
    const allowedSize = muiltiplier * oneMegaByte;

    if (file.size > allowedSize) {
      this._toasterService.warning(`O tamanho máximo do arquivo permitido é de ${muiltiplier}MB`, 'Tamanho máximo excedido');
      return;
    }

    this._reader.readAsDataURL(file);
    this.form.patchValue({ formFile: file });
    this.form.markAsDirty();

  }
}
