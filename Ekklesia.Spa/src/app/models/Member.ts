import { BaseConverter } from "../components/shared/base-converter"
import { RoleEnum } from "./RoleEnum"


export class Member {
  id: string
  name: string
  phone: string
  photo: string
  role: RoleEnum
  roleName:string
  birthDay:Date

  get dateStr(): string {    
    return BaseConverter.DateToStringOnlyDate(this.birthDay)    
  }

  constructor() {
    this.id = ''
    this.name = ''
    this.phone = ''
    this.photo = ''
    this.roleName = '' 
    this.role = RoleEnum.INDEFINIDO
    this.birthDay = new Date
  }
}
