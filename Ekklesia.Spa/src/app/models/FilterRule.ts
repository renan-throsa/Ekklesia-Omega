import { FilterEnum } from "./FilterEnum";

export class FilterRule {
    Type: FilterEnum;
    Field: string
    Arg: string

    constructor(field: string = '', arg: string = '', type: FilterEnum = FilterEnum.Equal) {
        this.Field = field
        this.Arg = arg
        this.Type = type
    }
}