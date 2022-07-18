export enum RoleEnum {
  MEMBRO = 1,
  LIDER = 2,
  PROFESSOR = 3,
  INDEFINIDO = 4,
}

export const RoleMapping: Record<string | RoleEnum, string> = {
  [RoleEnum.MEMBRO]: 'Membro',
  [RoleEnum.LIDER]: 'Líder',
  [RoleEnum.PROFESSOR]: 'Professor(a)',
  [RoleEnum.INDEFINIDO]: 'Indefinido(a)',
}
