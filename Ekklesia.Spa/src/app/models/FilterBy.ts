export class FilterBy {
    type: number;
    field: string;
    arg: string;
  
    constructor(type: number, field: string, arg: string) {
      this.type = type;
      this.field = field;
      this.arg = arg;
    }
  }