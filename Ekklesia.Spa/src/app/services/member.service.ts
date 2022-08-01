import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Member } from '../models/Member'
import { ApplicationService } from './application.service'

@Injectable({
  providedIn: 'root',
})
export class MemberService extends ApplicationService<Member> {
  constructor(http: HttpClient) {
    super(http, 'Member')
  }
}
