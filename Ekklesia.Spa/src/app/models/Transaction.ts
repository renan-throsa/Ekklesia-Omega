
import { BaseConverter } from '../utils/base-converter'
import { Member } from './Member'
import { TransactionEnum } from './TransactionEnum'

export class Transaction {
  id: string
  date: string
  amount: number
  type: TransactionEnum
  typeName: string
  description: string
  receipt: string
  responsable: Member | undefined

  public get dateStr() {    
    return BaseConverter.DateToString(new Date(this.date))
  }
  
  public get amountStr(){    
    return `R$ ${this.amount}`
  }

  constructor() {
    this.id = ''
    this.date = ''
    this.amount = 0
    this.type = TransactionEnum.INDEFINIDO
    this.typeName = ''
    this.description = ''
    this.receipt = ''       
  }
}
