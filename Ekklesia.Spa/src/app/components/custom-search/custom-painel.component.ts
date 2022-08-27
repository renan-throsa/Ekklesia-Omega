import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core'
import { FaIconLibrary } from '@fortawesome/angular-fontawesome'
import { faPlus, faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-custom-painel',
  templateUrl: './custom-painel.component.html',
})
export class CustomPainelComponent {  
  @Output() search = new EventEmitter();

  constructor(private _library: FaIconLibrary) {
    this._library.addIcons(faPlus, faMagnifyingGlass)
  }

  onSearch() {
    this.search.emit();
  }
}
