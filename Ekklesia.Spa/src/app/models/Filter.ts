import { FilterRule } from "./FilterRule";
import { OrderRule } from "./OrderRule";

export class Filter {

    OrderBy: Array<OrderRule>
    FilterBy: Array<FilterRule>
    PageNumber: number;
    PageSize: number;

    constructor() {
        this.PageNumber = 1
        this.PageSize = 10
        this.OrderBy = []
        this.FilterBy = []
    }
}