import { Component } from '@angular/core'
import { FaIconLibrary } from '@fortawesome/angular-fontawesome'
import { faDove } from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-custom-menu',
  templateUrl: './custom-menu.component.html',
})
export class CustomMenuComponent {
  isCollapsed: boolean
  nav: Nav[]
  constructor(library: FaIconLibrary) {
    library.addIcons(faDove)
    this.isCollapsed = true
    this.nav = [
      { link: '/member', name: 'Membros', exact: true },
      { link: '/transaction', name: 'Transações', exact: true },
      { link: '/account', name: 'Perfil', exact: true },
    ]
  }

  collapse() {
    this.isCollapsed = !this.isCollapsed
    console.log(this.isCollapsed)
  }
}

interface Nav {
  link: string
  name: string
  exact: true
}
