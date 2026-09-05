import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmprestimoCreate } from '../DTO/EmprestimoCreate';
import { Livros } from '../models/livro';

@Injectable({
  providedIn: 'root',
})
export class LivrosService {

  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:5057/api/Livros';

  getLivros(): Observable<Livros[]> {
    return this.http.get<Livros[]>(this.apiUrl);
  }

  postLivros(Livros: Livros): Observable<Livros> {
    return this.http.post<Livros>(this.apiUrl, Livros);
  }


  getLivrosById(id: number): Observable<Livros> {
    return this.http.get<Livros>(
      `${this.apiUrl}/${id}`
    );
  }

  devolverLivro(id: number): Observable<Livros> {
    return this.http.put<Livros>(
      `${this.apiUrl}/${id}/devolver`,
      {}
    );
  }
}
