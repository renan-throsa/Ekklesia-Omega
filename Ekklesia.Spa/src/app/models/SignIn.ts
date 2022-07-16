export class SignIn {
  email: string
  password: string
  remember: boolean

  constructor() {
    this.email = ''
    this.password = ''
    this.remember = false
  }
}
