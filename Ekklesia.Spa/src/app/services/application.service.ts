import { HttpClient } from '@angular/common/http'
import { Observable, pluck } from 'rxjs'
import { BaseService } from './base.service'

export abstract class ApplicationService<T> extends BaseService {
  constructor(http: HttpClient, controller: string) {
    super(http, controller)
  }

  public browse(): Observable<any> {
    return this.http.get(this.baseUrl)
  }

  public read(id: string): Observable<any> {
    return this.http.get(this.baseUrl + '/' + id).pipe(
      pluck('payload')
    )
  }

  public add(entidade: T): Observable<any> {
    return this.http.post(this.baseUrl, entidade).pipe(pluck('payload'))
  }

  public edit(entidade: T): Observable<any> {
    return this.http.put(this.baseUrl, entidade).pipe(pluck('payload'))
  }
}
