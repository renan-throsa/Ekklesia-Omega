import { ParameterType } from "./ParamterEnum";

export class SearchParameter {
    Fild: string;
    PlaceHolder: string
    Type: ParameterType

    constructor() {
        this.Fild = ''
        this.PlaceHolder = ''
        this.Type = ParameterType.Text
    }
}