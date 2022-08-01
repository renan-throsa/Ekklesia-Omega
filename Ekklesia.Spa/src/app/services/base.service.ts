import { HttpClient, HttpHeaders } from '@angular/common/http'
import { environment } from 'src/environments/environment'

export abstract class BaseService {
  public readonly baseUrl: string

  constructor(
    protected http: HttpClient,
    protected readonly controller: string,
  ) {
    const configBaseServiceURL = environment.urlAPI
    this.baseUrl = configBaseServiceURL + this.controller
  }

  protected getHeader() {
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' })
    return {
      headers: headers,
    }
  }
}
