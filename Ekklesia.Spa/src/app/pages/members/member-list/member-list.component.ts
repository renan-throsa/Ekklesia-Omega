import { Component, OnInit } from '@angular/core'
import { NgxSpinnerService } from 'ngx-spinner'
import { ToastrService } from 'ngx-toastr'
import { finalize, pluck } from 'rxjs'
import { BaseTable } from 'src/app/components/shared/base-table'
import { Filtering } from 'src/app/models/Filtering'
import { Member } from 'src/app/models/Member'
import { MemberService } from 'src/app/services/member.service'

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: [],
})
export class MemberListComponent extends BaseTable<Member> implements OnInit {
  members: Member[]

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
    this._spinner.show()
    const observer = {
      next: (result: Member[]) => {
        this.members = result
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
      .browse(new Filtering())
      .pipe(pluck('payload', 'data'), finalize(() => this._spinner.hide()))
      .subscribe(observer);
  }
}
