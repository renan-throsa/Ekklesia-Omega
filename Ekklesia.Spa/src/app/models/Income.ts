import { IncomeEnum } from './IncomeEnum'

export class Income {
  revenueType: IncomeEnum
  observation: string

  constructor() {
    this.revenueType = IncomeEnum.INDEFINIDO
    this.observation = ''
  }
}
