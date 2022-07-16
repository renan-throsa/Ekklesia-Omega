import { Role } from './Role'

export class Member {
  id: string
  name: string
  phone: string
  photo: string
  role: Role

  constructor() {
    this.id = ''
    this.name = ''
    this.phone = ''
    this.photo = ''
    this.role = Role.MEMBRO
  }
}
