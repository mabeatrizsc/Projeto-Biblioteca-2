export interface Emprestimo {
  id: number;
  usuarioId: number;
  livroId: number;
  dataEmprestimo: string;
  dataPrevistaDevolucao: string;
  dataDevolucao: string | null;
}
