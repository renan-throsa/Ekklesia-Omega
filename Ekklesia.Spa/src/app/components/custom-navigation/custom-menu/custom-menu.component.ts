import { Component } from '@angular/core'
import { FaIconLibrary } from '@fortawesome/angular-fontawesome'
import {
  faDove,
  faPeopleGroup,
  faMoneyBillTransfer,
  faCalendar,
} from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-custom-menu',
  templateUrl: './custom-menu.component.html',
})
export class CustomMenuComponent {
  toggleNavbar = true
  nav: Nav[]
  constructor(private _library: FaIconLibrary) {
    _library.addIcons(faDove, faPeopleGroup, faMoneyBillTransfer, faCalendar)
    this.nav = [
      {
        link: '/member',
        name: 'Membros',
        icon: {iconName: 'people-group', prefix: 'fas'},
        exact: true,
      },
      {
        link: '/transaction',
        name: 'Transações',
        icon: {iconName: 'money-bill-transfer', prefix: 'fas'},
        exact: true,
      },
      {
        link: '/occasion',
        name: 'Eventos',
        icon: {iconName: 'calendar', prefix: 'fas'},
        exact: true,
      },
    ]
  }
}

interface Nav {
  link: string
  name: string
  icon: any
  exact: true
}
