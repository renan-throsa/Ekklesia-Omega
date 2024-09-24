import { Component, Input, OnInit } from '@angular/core'
import { NgxSpinnerService } from 'ngx-spinner'
import { ToastrService } from 'ngx-toastr'
import { finalize, pluck } from 'rxjs'
import { BaseTable } from 'src/app/components/shared/base-table'
import { FilterBy } from 'src/app/models/FilterBy'
import { FilterEnum } from 'src/app/models/filterEnum'
import { Filtering } from 'src/app/models/Filtering'
import { Member } from 'src/app/models/Member'
import { MemberService } from 'src/app/services/member.service'

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: [],
})
export class MemberListComponent extends BaseTable<Member> implements OnInit {

  @Input() members: Member[]

  constructor(
    private _memberService: MemberService,
    private _spinner: NgxSpinnerService,
    private _toasterService: ToastrService,
  ) {
    super()
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
    this.onSearch();
  }

  onSearch(filterBy:string = ''): void{
    this._spinner.show()
    const observer = {
      next: (result: Member[]) => { 
        this.members = result.map(item => Object.assign(new Member(), item));
      },
      error: (error: any) => {
        this._toasterService.error(
          'Algo deu errado 😵. Tente novamente mais tarde.',
          'Erro',
        )
        console.error('Erro:' + error.statusText)
      },
    }

    let filter = new Filtering();

    if (filterBy.length > 0) {
      filter.filterBy = [ new FilterBy(FilterEnum.Like,'name',filterBy)];
    }

    this._memberService
      .browse(filter)
      .pipe(pluck('data'), finalize(() => this._spinner.hide()))
      .subscribe(observer);
  }
}
