import { OrderEnum } from "./OrderEnum"

export class OrderRule {
    Field: string
    Direction: OrderEnum

    constructor() {
        this.Field = ''
        this.Direction = OrderEnum.Ascending
    }
}