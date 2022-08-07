import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable, pluck } from 'rxjs'
import { SignIn } from '../models/SignIn'
import { SignUp } from '../models/SignUp'
import { BaseService } from './base.service'

@Injectable({
  providedIn: 'root',
})
export class IdentityService extends BaseService {
  constructor(http: HttpClient) {
    super(http, 'Account')
  }

  signIn(user: SignIn): Observable<any> {
    return this.http.post(this.baseUrl + '/SignIn', user).pipe(pluck('payload'))
  }

  signUp(user: SignUp): Observable<any> {
    return this.http.post(this.baseUrl + '/SignUp', user).pipe(pluck('payload'))
  }

  isAuthenticated(): boolean {
    return this.getToken() ? true : false
  }

  logOut() {
    this.cleanUserDataLocaly()
  }
}
