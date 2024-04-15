import { HttpClient, HttpHeaders } from '@angular/common/http'
import { environment } from 'src/environments/environment'
import { Account } from '../models/Account'

export abstract class BaseService {
  public readonly baseUrl: string
  public readonly user: Account

  constructor(
    protected _http: HttpClient,
    protected readonly _controller: string,
  ) {
    const configBaseServiceURL = environment.urlAPI
    this.baseUrl = configBaseServiceURL + this._controller
    this.user = new Account()
  }

  protected getHeader(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${this.getToken()}`,
    })
  }

  public isAuthenticated(): boolean {
    return localStorage.getItem('ekklesia.token') ? true : false
  }

  public isTokenValid(): boolean {
    const expiresAt = localStorage.getItem('ekklesia.expiresAt')
    if (!expiresAt) {
      return false
    }
    return new Date(expiresAt).getTime() > new Date().getDate()
  }

  public getUser(): Account {
    let user = localStorage.getItem('ekklesia.user')
    user ? Object.assign(this.user, JSON.parse(user)) : null
    return this.user
  }

  public getToken(): string {
    const token = localStorage.getItem('ekklesia.token')
    return token ? token : ''
  }

  public saveUserData(response: any) {
    this.saveToken(response.token)
    this.saveUser(response.user)
    this.saveExpirationTime(response.expiresAt)
  }

  protected cleanUserData() {
    localStorage.removeItem('ekklesia.token')
    localStorage.removeItem('ekklesia.user')
    localStorage.removeItem('ekklesia.expiresAt')
  }

  protected saveToken(token: string) {
    localStorage.setItem('ekklesia.token', token)
  }

  protected saveUser(user: string) {
    localStorage.setItem('ekklesia.user', JSON.stringify(user))
  }

  protected saveExpirationTime(time: string) {
    localStorage.setItem('ekklesia.expiresAt', time)
  }
}
