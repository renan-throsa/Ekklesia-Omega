import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FilterEnum } from 'src/app/models/FilterEnum';
import { FilterRule } from 'src/app/models/FilterRule';
import { RoleEnum, RoleMapping } from 'src/app/models/RoleEnum';
import { UtilsValidators } from 'src/app/utils/utils-validators';

@Component({
  selector: 'app-member-search',
  templateUrl: './member-search.component.html'
})
export class MemberSearchComponent implements OnInit {
  form: FormGroup
  roles: (string | RoleEnum)[]
  roleapping = RoleMapping

  get isNameInvalid(): boolean {
    return this.hasErros('name')
  }

  get controls(): { [key: string]: AbstractControl } {
    return this.form.controls
  }
  constructor(private _formBuilder: FormBuilder,) {
    this.roles = Object.values(RoleEnum).filter((value) => typeof value === 'number')
    this.form = this._formBuilder.group({
      name: [
        '',
        [
          Validators.maxLength(50),
          UtilsValidators.withoutNumbers,
          UtilsValidators.withoutSpecialCharacter,
        ],
      ],
      role: [''],
    })
  }

  ngOnInit(): void {
  }

  private hasErros(field: string): boolean {
    const hasErros =
      this.form.get(field)?.errors &&
      (this.form.get(field)?.dirty || this.form.get(field)?.touched)
    return Boolean(hasErros)
  }

  searchBy(): FilterRule[] {
    const member: SearchMember = Object.assign(new SearchMember(), this.form.value)
    let filterBy = Array<FilterRule>();
    if (member.name) {
      filterBy.push(new FilterRule('Name', member.name, FilterEnum.Like));
    }
    if (member.role) {
      filterBy.push(new FilterRule('Role', member.role?.toString(), FilterEnum.Equal));
    }
    return filterBy;
  }
}

class SearchMember {
  name: string = ''
  role: RoleEnum | undefined
}
