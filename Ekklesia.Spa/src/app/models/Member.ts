import { BaseConverter } from '../utils/base-converter'
import { RoleEnum } from './RoleEnum'

export class Member {
  id: string
  name: string
  phone: string
  photo: string
  role: RoleEnum
  roleName: string
  birthDay: string
  formFile?: File  
  BaseConverter: any

  constructor() {
    this.id = '';
    this.name = '';
    this.phone = '';
    this.photo = '';
    this.roleName = '';
    this.birthDay = '';
    this.role = RoleEnum.INDEFINIDO;
  }
  
}
