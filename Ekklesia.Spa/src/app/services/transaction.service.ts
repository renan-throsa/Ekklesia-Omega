import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Transaction } from '../models/Transaction'
import { BaseService } from './base.service'

@Injectable({
  providedIn: 'root',
})
export class TransactionService extends BaseService<Transaction> {
  constructor(http: HttpClient) {
    super(http, 'Transaction')
  }
}
