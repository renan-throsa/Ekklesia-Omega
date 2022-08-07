import { HttpClient } from '@angular/common/http'
import { Observable, pluck } from 'rxjs'
import { BaseService } from './base.service'

export abstract class ApplicationService<T> extends BaseService {
  constructor(http: HttpClient, controller: string) {
    super(http, controller)
  }

  public browse(): Observable<any> {
    return this._http.get(this.baseUrl, { headers: this.getHeader() })
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
