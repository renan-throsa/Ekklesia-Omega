export class LocalStorageUtils {

  public getUser(): string {
    let user = localStorage.getItem('ekklesia.user')
    return user ? JSON.parse(user) : ''
  }

  public saveUserDataLocaly(response: any) {
    this.saveUserToken(response.accessToken)
    this.saveUser(response.userToken)
  }

  public cleanUserDataLocaly() {
    localStorage.removeItem('ekklesia.token')
    localStorage.removeItem('ekklesia.user')
  }

  public getUserToken(): string | null {
    return localStorage.getItem('ekklesia.token')
  }

  public saveUserToken(token: string) {
    localStorage.setItem('ekklesia.token', token)
  }

  public saveUser(user: string) {
    localStorage.setItem('ekklesia.user', JSON.stringify(user))
  }
}
