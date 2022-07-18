import { RoleEnum } from "./RoleEnum"


export class Member {
  id: string
  name: string
  phone: string
  photo: string
  role: RoleEnum
  roleName:string

  constructor() {
    this.id = ''
    this.name = ''
    this.phone = ''
    this.photo = ''
    this.roleName = '' 
    this.role = RoleEnum.INDEFINIDO
  }
}
