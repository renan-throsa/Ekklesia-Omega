import { Injectable } from '@angular/core'
import { CanLoad, Router } from '@angular/router'
import { ToastrService } from 'ngx-toastr'
import { IdentityService } from './identity.service'

@Injectable()
export class IdentityGard implements CanLoad {
  constructor(
    private _toasterService: ToastrService,
    private _router: Router,
    private _accountService: IdentityService,
  ) {}
  canLoad(): boolean {
    const valid = this._accountService.isAuthenticated && this._accountService.isTokenValid
    if (!valid) {
      this._toasterService.warning(
        '🤖💬 Token inválido ou expirado',
        'Registre-se novamente.',
      )
      localStorage.removeItem('ekklesia.token');
      this._router.navigate(['/account/signin']);
    }
    return valid
  }
  

}
