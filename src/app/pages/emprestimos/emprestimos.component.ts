import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { EmprestimoService } from '../../core/services/emprestimoService';
import { EmprestimoCreate } from '../../core/DTO/EmprestimoCreate';
import { LivrosService } from '../../core/services/livrosService';
import { Livros } from '../../core/models/livro';
import { Router } from '@angular/router';

@Component({
  selector: 'emprestimos',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './emprestimos.component.html',
  styleUrl: './emprestimos.component.scss'
})
export class EmprestimosComponent implements OnInit{
  
  
  ngOnInit(): void {
    this.carregarLivros()
    console.log(this.carregarLivros())
  }

  private livrosService = inject(LivrosService);
  private fb = inject(FormBuilder);
  private emprestimoService = inject(EmprestimoService);
  private router = inject(Router)

  livrosDisponiveis: Livros[] = [];


  mensagem = '';
  erro = '';

  form = this.fb.group({
    usuarioId: [null as number | null, Validators.required],
    livroId: [null as number | null, Validators.required],
    prazoDias: [14 as 7 | 14 | 21, Validators.required]
  });


  carregarLivros(): void {
    this.livrosService.getLivros().subscribe({
      next: (livros: Livros[]) => {
        this.livrosDisponiveis = livros.filter(
      livro => livro
        );
      },
      error: (error) => {
        console.error('Erro ao carregar livros:', error);
      }
    });
  }

  enviar() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }
    const dados: EmprestimoCreate = {
      usuarioId: this.form.value.usuarioId!,
      livroId: this.form.value.livroId!,
      prazoDias: this.form.value.prazoDias!
    };
    this.emprestimoService
      .postEmprestimo(dados)
      .subscribe({
        next: (emprestimo) => {
          console.log('Empréstimo criado:', emprestimo);
          this.mensagem = 'Empréstimo realizado com sucesso!';
          this.erro = '';
          this.form.reset({
            prazoDias: 14
          });
        },

        error: (error) => {
          console.error(error);
          this.erro =
            error.error ?? 'Erro ao realizar empréstimo.';
          this.mensagem = '';
        }
      });
  }

  cancelar(): void {
    this.router.navigate(['/dashboard']);
  }
}
