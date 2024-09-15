import { HttpClient, HttpHeaders } from '@angular/common/http'
import { environment } from 'src/environments/environment'

export abstract class BaseService {
  public readonly baseUrl: string

  constructor(
    protected _http: HttpClient,
    protected readonly _controller: string,
  ) {
    const configBaseServiceURL = environment.urlAPI;
    this.baseUrl = configBaseServiceURL + this._controller;    
  }

  protected getHeader(): HttpHeaders {
    return new HttpHeaders({      
      Authorization: `Bearer ${this.getToken()}`,
    })
  }  

  protected getToken(): string | null{
   return localStorage.getItem('ekklesia.token');
  }
  
}
