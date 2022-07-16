import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Member } from '../models/Member'
import { BaseService } from './base.service'

@Injectable({
  providedIn: 'root',
})
export class AccountService extends BaseService<Member> {
  constructor(http: HttpClient) {
    super(http, 'Account')
  }
}
