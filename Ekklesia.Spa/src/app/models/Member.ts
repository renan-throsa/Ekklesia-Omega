import { Role } from './Role'

export class Member {
  name: string
  phone: string
  photo: string
  role: Role

  constructor() {
    this.name = ''
    this.phone = ''
    this.photo = ''
    this.role = Role.MEMBRO
  }
}
