import { FilterEnum } from "./filterEnum";

export class FilterBy {
    type: FilterEnum;
    field: string;
    arg: string;
  
    constructor(type: FilterEnum, field: string, arg: string) {
      this.type = type;
      this.field = field;
      this.arg = arg;
    }
  }