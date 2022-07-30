import { Member } from './Member'

export class Expense {
  receipt: string
  description: string
  responsable: Member
 
  constructor() {
    this.receipt = ''
    this.description = ''
    this.responsable = new Member()
  }
}
