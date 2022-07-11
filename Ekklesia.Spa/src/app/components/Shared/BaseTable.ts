import { Component, EventEmitter, Input, Output } from '@angular/core'
import { Column } from '../custon-table/Column'

@Component({ template: '' })
export abstract class BaseTable<T> {
  @Input()
  protected _list: T[] = []
  public get list(): T[] {
    return this._list
  }
  public set list(value: T[]) {
    this._list = value
  }
  @Output() listChange = new EventEmitter()

  @Input() columns: Column[]

  constructor() {
    this.columns = []
  }
}
