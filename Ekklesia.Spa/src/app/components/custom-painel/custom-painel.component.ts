import { Component, Input } from '@angular/core'
import { FaIconLibrary } from '@fortawesome/angular-fontawesome'
import { faPlus, faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-custom-painel',
  templateUrl: './custom-painel.component.html',
})
export class CustomPainelComponent {
  @Input() searchBy: string
  constructor(private _library: FaIconLibrary) {
    this.searchBy = ''
    this._library.addIcons(faPlus, faMagnifyingGlass)
  }
}
