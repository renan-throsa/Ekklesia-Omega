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

import { Member } from 'src/app/models/Member'
import { MemberService } from 'src/app/services/member.service'
import { RoleEnum, RoleMapping } from 'src/app/models/RoleEnum'
import { NgxSpinnerService } from 'ngx-spinner'
import { finalize, map, tap } from 'rxjs'

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styles: [`
    .card-footer > button + button {
      margin-left: 1%;
    }
  `]
})
export class MemberEditComponent implements OnInit {
  form: UntypedFormGroup
  roles: (string | RoleEnum)[]
  roleapping = RoleMapping
  MASKS = MASKS
  maxDate: Date
  imageBase64!: string;

  private readonly _reader: FileReader;

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

  get isDateInvalid(): boolean {
    return this._hasErros('birthDay')
  }

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private _formBuilder: UntypedFormBuilder,
    private _memberService: MemberService,
    private _toasterService: ToastrService,
    private _spinner: NgxSpinnerService,
  ) {
    this.maxDate = new Date();
    this._reader = new FileReader();
    this._reader.onload = (e: any) => {
      this.imageBase64 = `data:image/png;base64,${e.target.result.split(',')[1]}`;
    };

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
      birthDay: ['', [Validators.required, UtilsValidators.maxDate(this.maxDate)]],
      formFile: [null]
    })
  }
  ngOnInit(): void {
    this._spinner.show()
    let observer = {
      next: (member: Member) => {                
        member.birthDay = new Date(member.birthDay).toISOString().split('T')[0];
        
        this.form.patchValue({ id: member.id });
        this.form.patchValue({ name: member.name });
        this.form.patchValue({ phone: member.phone });
        this.form.patchValue({ role: member.role });
        this.form.patchValue({ birthDay: member.birthDay });
        this.imageBase64 = member.photo;

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
        .pipe(map(response => Object.assign(new Member(), response)), finalize(() => this._spinner.hide()))
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
    member.phone = member.phone.replace(/\D/g, '');

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
