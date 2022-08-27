export class FilterResult<T>{
    data: Array<T>
    page: number
    perPage: number
    pages: number
    total: number

    constructor() {
        this.data = []
        this.page = 0
        this.perPage = 0
        this.pages = 0
        this.total = 0
    }
}