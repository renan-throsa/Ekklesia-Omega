
import { BaseConverter } from '../utils/base-converter'
import { Member } from './Member'
import { TransactionEnum, TransactionMapping } from './TransactionEnum'

export class Transaction {
  id: string
  date: string
  amount: number
  typeName: string
  description: string
  receipt: string
  responsable: Member | undefined

  private _type : TransactionEnum;

  public get type() : TransactionEnum {
    return this._type;
  }
  public set type(v : TransactionEnum) {
    this._type = v;
    this.typeName = TransactionMapping[v]    
  }

  public get dateStr() {    
    return BaseConverter.DateToString(new Date(this.date));
  }
  
  public get amountStr(){    
    return `R$ ${this.amount}`;
  }

  constructor() {
    this.id = '';
    this.date = '';
    this.amount = 0;    
    this.typeName = '';
    this.description = '';
    this.receipt = '';       
    this._type = TransactionEnum.INDEFINIDO;
  }
}
