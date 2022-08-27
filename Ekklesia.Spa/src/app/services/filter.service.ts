import { Injectable } from "@angular/core";
import { Filter } from "../models/Filter";

@Injectable({ providedIn: 'root' })
export class FilterService {

    private _isFilterSaved: boolean
    private _filter: Filter;
    public get Filter(): Filter {
        return Object.assign(new Filter(), this._filter);
    }

    constructor() {
        this._filter = new Filter();
        this._isFilterSaved = false;
    }

}