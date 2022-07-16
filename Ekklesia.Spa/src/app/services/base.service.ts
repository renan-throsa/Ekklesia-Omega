import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs'
import { environment } from 'src/environments/environment'
import { DynamicEnviroment } from '../dynamic.environment'

export abstract class BaseService<T> {
  public readonly baseUrl: string

  constructor(
    protected http: HttpClient,
    protected readonly controller: string,
  ) {
    const denv = new DynamicEnviroment()
    const configBaseServiceURL = environment.urlAPI
    this.baseUrl = configBaseServiceURL + this.controller
  }

  public browse(): Observable<any> {
    return this.http.get(this.baseUrl)
  }

  public read(id: string): Observable<any> {
    return this.http.get(this.baseUrl + '/' + id)
  }

  public add(entidade: T): Observable<any> {
    return this.http.post(this.baseUrl, entidade)
  }

  public edit(entidade: T): Observable<any> {
    return this.http.put(this.baseUrl, entidade)
  }
}
