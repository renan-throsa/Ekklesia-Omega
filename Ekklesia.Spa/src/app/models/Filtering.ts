import { FilterBy } from "./FilterBy";
import { OrderBy } from "./OrderBy";

export class Filtering {
    orderBy: OrderBy[] = [];
    filterBy: FilterBy[] = [];
    pageNumber: number = 1;
    pageSize: number = 10;
}