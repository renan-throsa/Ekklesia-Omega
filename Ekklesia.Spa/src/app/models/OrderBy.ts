export class OrderBy {
    field: string;
    direction: string;
  
    constructor(field: string, direction: string) {
      this.field = field;
      this.direction = direction;
    }
  }