import { Injectable } from '@angular/core'
import { CanDeactivate } from '@angular/router'
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'
import { CustomModalComponent } from '../components/custom-modal/custom-modal.component'
import { MemberEditComponent } from '../pages/members/member-edit/member-edit.component'
import { MemberNewComponent } from '../pages/members/member-new/member-new.component'

@Injectable()
export class InputGuard
  implements CanDeactivate<MemberNewComponent | MemberEditComponent> {
  constructor(private _modalService: NgbModal) {}

  canDeactivate(
    component: MemberNewComponent | MemberEditComponent,
  ): Promise<boolean> {
    if (component.form.dirty) {
      const modalRef = this._modalService.open(CustomModalComponent)
      modalRef.componentInstance.title = 'Deseja sair?'
      modalRef.componentInstance.message =
        'As alterações não salvas serão perdidas'
      return modalRef.result.then(
        (res) => {
          return true
        },
        (dismiss) => {
          return false
        },
      )
    }
    return Promise.resolve(true)
  }
}
