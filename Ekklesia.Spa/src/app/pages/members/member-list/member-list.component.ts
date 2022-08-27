import { Component, OnInit, ViewChild } from '@angular/core'
import { NgxSpinnerService } from 'ngx-spinner'
import { ToastrService } from 'ngx-toastr'
import { finalize, map, Observable, tap } from 'rxjs'
import { BaseTable } from 'src/app/components/shared/base-table'
import { Filter } from 'src/app/models/Filter'
import { FilterResult } from 'src/app/models/FilterResult'
import { Member } from 'src/app/models/Member'
import { MemberService } from 'src/app/services/member.service'
import { MemberSearchComponent } from '../member-search/member-search.component'

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html'
})
export class MemberListComponent extends BaseTable<Member> implements OnInit {
  private _filter: Filter;

  @ViewChild('memberSearch', { static: false }) private memberSearch!: MemberSearchComponent
  members: Member[]

  constructor(
    private _memberService: MemberService,
    private _spinner: NgxSpinnerService,
    private _toasterService: ToastrService,
  ) {
    super()
    this._filter = new Filter()
    this.members = []
    this.columns = [
      {
        name: 'Nome',
        field: 'name',
      },
      {
        name: 'Telefone',
        field: 'phone',
      },
      {
        name: 'Cargo',
        field: 'roleName',
      },
    ]
  }

  ngOnInit(): void {
    this._spinner.show()
    const observer = {
      next: (result: FilterResult<Member>) => {
        this.members = result.data
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
      .browse(this._filter)
      .pipe(finalize(() => this._spinner.hide()))
      .subscribe(observer)
  }

  search() {
    this._spinner.show()
    const observer = {
      next: (result: FilterResult<Member>) => {
        this.members = result.data
      },
      error: (error: any) => {
        this._toasterService.error(
          'Algo deu errado 😵. Tente novamente mais tarde.',
          'Erro',
        )
        console.error('Erro:' + error.statusText)
      },
    }
    
    this._filter.FilterBy = this.memberSearch.searchBy()
    this._memberService
      .browse(this._filter)
      .pipe(finalize(() => this._spinner.hide()))
      .subscribe(observer)
  }
}
