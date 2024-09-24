import { Component, EventEmitter, Input, Output } from '@angular/core'
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms'
import { FaIconLibrary } from '@fortawesome/angular-fontawesome'
import { faPlus, faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-custom-painel',
  templateUrl: './custom-painel.component.html',
})
export class CustomPainelComponent {
  form: UntypedFormGroup
  @Input() searchByField: string = ''
  @Output() searchByEvent : EventEmitter<string> = new EventEmitter<string>()

  constructor(private _library: FaIconLibrary,private _formBuilder: UntypedFormBuilder) {
    this.form = this._formBuilder.group({
      searchByField: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(50),         
        ],
      ],      
    })    
    this._library.addIcons(faPlus, faMagnifyingGlass)
  }

  onSubmit() {    
    this.searchByEvent.emit(this.form.get('searchByField')?.value);
  }
}
