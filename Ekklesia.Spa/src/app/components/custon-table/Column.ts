export class Column {    
    name?: string;
    field?: string;
    type?: FieldTypes;
    groupable?: boolean;
    enable?: boolean;
}

export enum FieldTypes {
    Int = "int",
    Date = "date",
    String = "string",
    Double = "double",
    Object = "object"
}

export declare class PageInfo {
    page: number;
    groupPageSize?: number;
    tablePageSize?: number;
    totalCount: number;
}