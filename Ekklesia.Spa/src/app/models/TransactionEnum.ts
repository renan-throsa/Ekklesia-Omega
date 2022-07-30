export enum TransactionEnum {
  DIZIMO = 1,
  OFERTA = 2,
  DESPESA = 3,
  INDEFINIDO = 4,
}

export const TransactionMapping: Record<string | TransactionEnum, string> = {
  [TransactionEnum.DIZIMO]: 'Dízimo',
  [TransactionEnum.OFERTA]: 'Oferta',
  [TransactionEnum.DESPESA]: 'Despesa',
  [TransactionEnum.INDEFINIDO]: 'Indefinido',
}
