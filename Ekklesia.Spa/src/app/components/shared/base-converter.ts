export class BaseConverter {
  public static DateToString(data: Date) {
    if (data == null) {
      return ''
    }
    return `${this.prependZero(data.getDate())}/${this.prependZero(
      data.getMonth() + 1,
    )}/${data.getFullYear()} ${this.prependZero(
      data.getHours(),
    )}:${this.prependZero(data.getMinutes())}:${this.prependZero(
      data.getSeconds(),
    )}`
  }

  public static DateToStringOnlyDate(data: Date) {
    return `${this.prependZero(data.getDate())}/${this.prependZero(
      data.getMonth() + 1,
    )}/${data.getFullYear()}`
  }

  private static prependZero(valor: number) {
    if (valor <= 9) {
      return '0' + valor
    }
    return valor + ''
  }

  public static StringToDate(value: string) {   
    let date, time, dia, mes, ano, hora, minuto, segundo
    ;[date, time] = value.split('T')
    ;[ano, mes, dia] = date.split('-')
    ;[hora, minuto, segundo] = time.split(':')

    return new Date(Number(ano), Number(mes) - 1, Number(dia), Number(hora),Number(minuto), Number(segundo.substring(0, 2)))
  }

  public static StringToDateOnlyDate(value: string) {
    let dia: string, mes: string, ano: string
    ;[dia, mes, ano] = value.split('/')
    return new Date(Number(ano), Number(mes) - 1, Number(dia))
  }

  public static resolveField(obj: any, field: string): any {
    if (field == null || field.trim() === '') {
      return null
    }
    let fields = field.split('.')
    if (fields.length > 1) {
      const campo = fields[0]
      fields = fields.slice(1)
      if (obj[campo] != null) {
        return this.resolveField(obj[campo], fields.join('.'))
      }
    }
    if (typeof obj[field] === 'number') {
      return obj[field].toLocaleString()
    }
    if (typeof obj[field] === 'number') {
      return obj[field].toLocaleString()
    }
    return obj[field]
  }
}
