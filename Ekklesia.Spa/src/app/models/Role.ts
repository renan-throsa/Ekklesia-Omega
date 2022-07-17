export enum Role {
  MEMBRO = 1,
  LIDER = 2,
  PROFESSOR = 3,
  INDEFINIDO = 4,
}

export const RoleMapping: Record<string | Role, string> = {
  [Role.MEMBRO]: 'Membro',
  [Role.LIDER]: 'Líder',
  [Role.PROFESSOR]: 'Professor(a)',
  [Role.INDEFINIDO]: 'Indefinido(a)',
}
