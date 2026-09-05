import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Emprestimo } from '../models/emprestimo';
import { Observable } from 'rxjs';
import { EmprestimoCreate } from '../DTO/EmprestimoCreate';

@Injectable({
  providedIn: 'root',
})
export class EmprestimoService {

  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:5057/api/Emprestimo';

  getEmprestimos(): Observable<Emprestimo[]> {
    return this.http.get<Emprestimo[]>(this.apiUrl);
  }

  postEmprestimo(emprestimo: EmprestimoCreate): Observable<Emprestimo> {
    return this.http.post<Emprestimo>(this.apiUrl, emprestimo);
  }


  getEmprestimoById(id: number): Observable<Emprestimo> {
    return this.http.get<Emprestimo>(
      `${this.apiUrl}/${id}`
    );
  }

  devolverLivro(id: number): Observable<Emprestimo> {
    return this.http.put<Emprestimo>(
      `${this.apiUrl}/${id}/devolver`,
      {}
    );
  }
}
