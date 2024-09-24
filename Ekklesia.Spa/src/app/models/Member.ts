import { RoleEnum, RoleMapping } from './RoleEnum'

export class Member {
  id: string
  name: string
  phone: string
  photo: string
  roleName: string
  birthDay: string
  formFile?: File  
  BaseConverter: any

  private _role : RoleEnum;

  public get role() : RoleEnum {
    return this._role;
  }
  public set role(v : RoleEnum) {
    this._role = v;
    this.roleName = RoleMapping[v]
  }

  constructor() {
    this.id = '';
    this.name = '';
    this.phone = '';
    this.photo = '';
    this.roleName = '';
    this.birthDay = '';
    this._role = RoleEnum.INDEFINIDO;
  }   
  
  
  
  
  
}
