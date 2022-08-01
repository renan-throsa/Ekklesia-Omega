import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Transaction } from '../models/Transaction'
import { ApplicationService } from './application.service'

@Injectable({
  providedIn: 'root',
})
export class TransactionService extends ApplicationService<Transaction> {
  constructor(http: HttpClient) {
    super(http, 'Transaction')
  }
}
