import { AbstractControl, ValidatorFn } from '@angular/forms'

export abstract class CustomValidators {
  static maxDate(maxDate: Date): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      let currentDate = new Date(control.value)
      return currentDate.getTime() > maxDate.getTime()
        ? { maxDate: control.value }
        : null
    }
  }

  static minDate(minDate: Date): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      let currentDate = new Date(control.value)      
      return currentDate.getTime() < minDate.getTime()
        ? { minDate: control.value }
        : null
    }
  }
}
