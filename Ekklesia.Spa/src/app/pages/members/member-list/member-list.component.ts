import { Component, OnInit } from '@angular/core'
import { BaseTable } from 'src/app/components/Shared/BaseTable'
import { Member } from 'src/app/models/Member'

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: [],
})
export class MemberListComponent extends BaseTable<Member> implements OnInit {
  constructor() {
    super()
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
        field: 'role',
      },
    ]
  }

  ngOnInit(): void {}
}
