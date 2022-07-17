import { Role } from './Role'

export class Member {
  id: string
  name: string
  phone: string
  photo: string
  role: Role
  roleName:string

  constructor() {
    this.id = ''
    this.name = ''
    this.phone = ''
    this.photo = ''
    this.roleName = '' 
    this.role = Role.INDEFINIDO
  }
}
