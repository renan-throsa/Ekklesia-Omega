import { Injectable } from '@angular/core'
import { CanLoad, Router } from '@angular/router'
import { ToastrService } from 'ngx-toastr'

@Injectable()
export class IdentityGard implements CanLoad {
  constructor(
    private _toasterService: ToastrService,
    private _router: Router,
  ) {}
  canLoad(): boolean {
    const valid = this._isAuthenticated() && this._isTokenValid()
    if (!valid) {
      this._toasterService.warning(
        '🤖💬 Token inválido ou expirado',
        'Registre-se novamente.',
      )
      this._cleanUserData()
      this._router.navigate(['/account/signin'])
    }
    return valid
  }

  private _isAuthenticated(): boolean {
    return localStorage.getItem('ekklesia.token') ? true : false
  }

  private _isTokenValid(): boolean {
    const expiresAt = localStorage.getItem('ekklesia.expiresAt')
    if (!expiresAt) {
      return false
    }
    return new Date(expiresAt).getTime() > new Date().getTime()
  }

  private _cleanUserData() {
    localStorage.removeItem('ekklesia.token')
    localStorage.removeItem('ekklesia.user')
    localStorage.removeItem('ekklesia.expiresAt')
  }
}
