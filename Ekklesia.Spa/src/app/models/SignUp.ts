export class SignUp {
  name: string
  phone: string
  email: string
  password: string
  confirmPasword: string
  remember: boolean

  constructor() {
    this.name = ''
    this.phone = ''
    this.email = ''
    this.password = ''
    this.confirmPasword = ''
    this.remember = false
  }
}
