import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Member } from '../models/Member'
import { BaseService } from './base.service'

@Injectable({
  providedIn: 'root',
})
export class MemberService extends BaseService<Member> {
  constructor(http: HttpClient) {
    super(http, 'Member')
  }
}
