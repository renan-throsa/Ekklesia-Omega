import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core'
import { strict } from 'assert'

@Component({
  selector: 'app-custom-select',
  templateUrl: './custom-select.component.html',
  styleUrls: [],
})
export class CustomSelectComponent implements OnInit {
  isOpen = false
  @Input() options: any[]
  @Input() field: string
  @Input() selected: any
  @Input() multiple = false
  @Input() label: string
  @Input() disabled = false
  @Input() style: any
  @Input() placeholder = 'Selecione'
  @Input() optional: boolean

  @Output() selectedChange = new EventEmitter()
  @Output() select: EventEmitter<any> = new EventEmitter<any>()

  constructor() {
    this.options = []
    this.field = ''
    this.label = ''
    this.optional = true
  }

  onChange(value: any) {
    this.selectedChange.emit(this.selected)
    if (this.select != null) {
      this.select.emit(value)
    }    
  }

  ngOnInit(): void {}
}

