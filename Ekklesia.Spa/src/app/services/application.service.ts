import { HttpClient } from '@angular/common/http'
import { Observable, pluck } from 'rxjs'
import { BaseService } from './base.service'
import { Filtering } from '../models/Filtering'

export abstract class ApplicationService<T extends object> extends BaseService {
  constructor(http: HttpClient, controller: string) {
    super(http, controller)
  }

  public browse(filter: Filtering): Observable<any> {
    return this._http.post(`${this.baseUrl}/Browse`, filter, { headers: this.getHeader() })
  }

  public read(id: string): Observable<any> {
    return this._http
      .get(`${this.baseUrl}/${id}`, { headers: this.getHeader() });
  }

  public add(entity: T): Observable<any> {
    return this._http
      .post(`${this.baseUrl}/Add`, this._toFormData(entity), { headers: this.getHeader() });
  }

  public edit(entity: T): Observable<any> {
    return this._http
      .put(`${this.baseUrl}/Edit/`, this._toFormData(entity), { headers: this.getHeader() });
  }

  private _toFormData(entity: T): FormData {
    const formData = new FormData();   

    for (const [key, value] of Object.entries(entity)) {

      if (key !== 'formFile' && typeof(value) === 'object' ) {
        for (const [innerkey, innervalue] of Object.entries(value)) {
          formData.append(innerkey.replace("_",""), innervalue as string);
        }     
         
      }else{
        formData.append(key.replace("_",""), value);
      }
      
      

    }

    

    return formData
  }
}
