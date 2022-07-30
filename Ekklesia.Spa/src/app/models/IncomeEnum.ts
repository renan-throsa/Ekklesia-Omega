export enum IncomeEnum {
  DÍZIMO = 1,
  OFERTA = 2,
  INDEFINIDO = 3,
}

export const IncomeMapping: Record<string | IncomeEnum, string> = {
  [IncomeEnum.DÍZIMO]: 'Dízimo',
  [IncomeEnum.OFERTA]: 'Oferta',
  [IncomeEnum.INDEFINIDO]: 'Indefinido',
}
