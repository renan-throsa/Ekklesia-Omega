export class Account {
  id:string
  name: string
  phone: string
  email: string

  constructor() {
    this.id = '';
    this.name = '';
    this.phone = '';
    this.email = '' ;   
  }

  get IsValid():boolean{
    return this.id.length > 0;
  }
}
