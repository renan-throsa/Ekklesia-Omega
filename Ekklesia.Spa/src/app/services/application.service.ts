import { HttpClient } from '@angular/common/http'
import { Observable, pluck } from 'rxjs'
import { Filter } from '../models/Filter'
import { BaseService } from './base.service'

export abstract class ApplicationService<T> extends BaseService {
  constructor(http: HttpClient, controller: string) {
    super(http, controller)
  }

  public browse(filter: Filter): Observable<any> {
    const endPoint = this.baseUrl + '/Browse'
    return this._http.post(endPoint, filter, { headers: this.getHeader() }).pipe(pluck('payload'))
  }

  public read(id: string): Observable<any> {
    return this._http
      .get(this.baseUrl + '/' + id, { headers: this.getHeader() })
      .pipe(pluck('payload'))
  }

  public add(entidade: T): Observable<any> {
    return this._http
      .post(this.baseUrl, entidade, { headers: this.getHeader() })
      .pipe(pluck('payload'))
  }

  public edit(entidade: T): Observable<any> {
    return this._http
      .put(this.baseUrl, entidade, { headers: this.getHeader() })
      .pipe(pluck('payload'))
  }
}
