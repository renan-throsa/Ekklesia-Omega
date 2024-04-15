import { Component, Input } from '@angular/core'
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap'

@Component({
  selector: 'app-custom-modal',
  templateUrl: './custom-modal.component.html',
})
export class CustomModalComponent {
  @Input() public message: string
  @Input() public title: string

  constructor(public modal: NgbActiveModal) {
    this.message =  'As alterações não salvas serão perdidas'
    this.title = 'Deseja sair?'
  }
}
