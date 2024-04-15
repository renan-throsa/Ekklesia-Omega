import { Account } from '../models/Account'

export class LocalStorageUtils {
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
