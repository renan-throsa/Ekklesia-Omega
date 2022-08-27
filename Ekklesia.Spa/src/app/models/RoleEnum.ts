export enum RoleEnum {
  MEMBRO = 1,
  LIDER = 2,
  PROFESSOR = 3
}

export const RoleMapping: Record<string | RoleEnum, string> = {
  [RoleEnum.MEMBRO]: 'Membro',
  [RoleEnum.LIDER]: 'Líder',
  [RoleEnum.PROFESSOR]: 'Professor(a)',  
}
