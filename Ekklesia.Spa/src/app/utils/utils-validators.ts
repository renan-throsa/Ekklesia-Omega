import { AbstractControl, ValidatorFn } from '@angular/forms'

export abstract class UtilsValidators {
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

  static withNumbers(control: AbstractControl): { [key: string]: any } | null {
    return control.value.match('[0-9]') ? null : { withNumbers: control.value }
  }

  static withoutNumbers(
    control: AbstractControl,
  ): { [key: string]: any } | null {
    return control.value.match('[0-9]')
      ? { withoutNumbers: control.value }
      : null
  }

  static withUpperCase(
    control: AbstractControl,
  ): { [key: string]: any } | null {
    return control.value.match('[A-Z]')
      ? null
      : { withUpperCase: control.value }
  }

  static withLowerCase(
    control: AbstractControl,
  ): { [key: string]: any } | null {
    return control.value.match('[a-z]')
      ? null
      : { withLowerCase: control.value }
  }

  static withSpecialCharacter(
    control: AbstractControl,
  ): { [key: string]: any } | null {
    return control.value.match('[{}@#$%¨&*£¢¬?!°<>.,:;/\'"`+-]')
      ? null
      : { withSpecialCharacter: control.value }
  }

  static withoutSpecialCharacter(
    control: AbstractControl,
  ): { [key: string]: any } | null {
    return control.value.match('[{}@#$%¨&*£¢¬?!°<>.,:;/\'"`+-]')
      ? { withoutSpecialCharacter: control.value }
      : null
  }
}
