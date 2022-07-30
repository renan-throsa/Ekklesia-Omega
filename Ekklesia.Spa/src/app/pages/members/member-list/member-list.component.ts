import { Component, OnInit } from '@angular/core'
import { BaseTable } from 'src/app/components/shared/base-table'
import { Member } from 'src/app/models/Member'
import { MemberService } from 'src/app/services/member.service'

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: [],
})
export class MemberListComponent extends BaseTable<Member> implements OnInit {
  members: Member[]
  constructor(private _memberService: MemberService) {
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
    this._memberService.browse().subscribe((result: Member[]) => {    
      this.members = result
    })
  }
}
