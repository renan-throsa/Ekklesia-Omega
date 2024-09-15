import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable, pluck, tap } from 'rxjs'
import { SignIn } from '../models/SignIn'
import { SignUp } from '../models/SignUp'
import { BaseService } from './base.service'
import { Account } from '../models/Account'
import { jwtDecode } from "jwt-decode";

@Injectable({
  providedIn: 'root',
})
export class IdentityService extends BaseService {
  
  public user!: Account;

  constructor(http: HttpClient) {
    super(http, 'Account');
    this.tryAuthenticate();    
  }
  
  signIn(user: SignIn): Observable<any> {
    return this._http.post(this.baseUrl + '/SignIn', user,{responseType:'text'});
  }

  signUp(user: SignUp): Observable<any> {
    return this._http.post(this.baseUrl + '/SignUp', user,{responseType:'text'});
  } 

  logOut() {
    this.cleanUserData()
  }

  public get isAuthenticated(): boolean {
    return this.user.IsValid;
  }

  public get isTokenValid(): boolean {
    let stringToken = this.getToken(); 

    if (!stringToken) {
      return false
    }

    let token = jwtDecode(stringToken); 

    if (!token.exp) {
      return false
    }          
    
    return new Date() <= new Date(token.exp * 1000);
  }

  public get User(): Account  {   
    return Object.assign(new Account,this.user);
  }
  

  public authenticate(stringToken: string):void {
    this.user = new Account();    
    this.saveToken(stringToken)    
    let token:any = jwtDecode(stringToken);
    this.createUser(token);
  }

  private tryAuthenticate():void {
    let stringToken = this.getToken();
    if (stringToken) {    
    let token:any = jwtDecode(stringToken);
    this.createUser(token)
    }else{
      this.user = new Account();
    }
  }

  private createUser(token:any){
    this.user = new Account()
    this.user.id = token.jti;
    this.user.name = token.unique_name;
    this.user.phone = token.mobilephone;
    this.user.email = token.email;
  }

  protected cleanUserData() {
    localStorage.removeItem('ekklesia.token')
  }

  protected saveToken(token: string) {
    localStorage.setItem('ekklesia.token', token)
  }
  
}
