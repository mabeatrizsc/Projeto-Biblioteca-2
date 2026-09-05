import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmprestimoCreate } from '../DTO/EmprestimoCreate';
import { Usuario } from '../models/usuario';

@Injectable({
  providedIn: 'root',
})
export class UsuarioService {

  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:5057/api/Usuario';

  getUsuarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.apiUrl);
  }

  postUsuario(Usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.apiUrl, Usuario);
  }


  getUsuarioById(id: number): Observable<Usuario> {
    return this.http.get<Usuario>(
      `${this.apiUrl}/${id}`
    );
  }

  devolverLivro(id: number): Observable<Usuario> {
    return this.http.put<Usuario>(
      `${this.apiUrl}/${id}/devolver`,
      {}
    );
  }
}
