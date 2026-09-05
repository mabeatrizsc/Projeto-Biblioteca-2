
export interface EmprestimoCreate {
  usuarioId: number;
  livroId: number;
  prazoDias: 7 | 14 | 21;
}