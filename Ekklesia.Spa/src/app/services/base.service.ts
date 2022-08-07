import { HttpClient, HttpHeaders } from '@angular/common/http'
import { environment } from 'src/environments/environment'
import { Account } from '../models/Account'

export abstract class BaseService {
  public readonly baseUrl: string
  constructor(
    protected http: HttpClient,
    protected readonly controller: string,
  ) {
    const configBaseServiceURL = environment.urlAPI
    this.baseUrl = configBaseServiceURL + this.controller
  }

  protected getHeader(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + this.getToken(),
    })
  }

  public getUser(): Account | null {
    let user = localStorage.getItem('ekklesia.user')
    return user ? Object.assign(new Account(), JSON.parse(user)) : null
  }

  public saveUserDataLocaly(response: any) {     
    this.saveToken(response.token)
    this.saveUser(response.user)
  }

  protected cleanUserDataLocaly() {
    localStorage.removeItem('ekklesia.token')
    localStorage.removeItem('ekklesia.user')
  }

  public getToken(): string {
    const token = localStorage.getItem('ekklesia.token')
    return token ? token : ''
  }

  public saveToken(token: string) {
    localStorage.setItem('ekklesia.token', JSON.stringify(token))
  }

  public saveUser(user: string) {
    localStorage.setItem('ekklesia.user', JSON.stringify(user))
  }
}
