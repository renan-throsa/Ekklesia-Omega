import { Injectable } from '@angular/core'
import { CanLoad } from '@angular/router'

@Injectable()
export class AuthGard implements CanLoad {
  canLoad(): boolean {
    return localStorage.getItem('ekklesia.token') ? true : false
  }
}
