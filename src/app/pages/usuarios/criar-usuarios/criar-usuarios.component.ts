import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { UsuarioService } from '../../../core/services/usuarioService';
import { Usuario } from '../../../core/models/usuario';

@Component({
  selector: 'criar-usuarios',
  imports: [ReactiveFormsModule],
  templateUrl: './criar-usuarios.component.html',
  styleUrl: './criar-usuarios.component.scss',
})
export class CriarUsuariosComponent {

    private fb = inject(FormBuilder)
    private usuarioService = inject(UsuarioService)
    constructor(
    ){}

    form = this.fb.group({
        nome: ['', [Validators.required, Validators.minLength(3)]],
        email: ['', [Validators.required, Validators.email]],
        telefone: ['' , [Validators.required]],
    })

    salvar(): void{
        console.log("AQUI!")
        if(this.form.invalid){
            console.log("TESTE!")
            this.form.markAllAsTouched();
            return;
        }
        console.log(this.form.value)
          const usuario: Usuario = {
                nome: this.form.value.nome!,
                email: this.form.value.email!,
                telefone: this.form.value.telefone!
            };
        this.usuarioService.postUsuario(usuario).subscribe({
            next: (resultado) => {
                console.log('Usuário criado!', resultado);
            },
            error: (error) => {
                console.error(error);
            }
            });
    }
}
