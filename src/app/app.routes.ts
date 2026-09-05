import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
    },
    {
        path: 'dashboard',
        loadComponent: () =>
            import('./pages/dashboard/dashboard.component')
                .then(m => m.DashboardComponent)
    },
    {
        path: 'livros',
        loadComponent: () =>
            import('./pages/livros/livros.component')
                .then(m => m.LivrosComponent)
    },
    {
        path: 'usuarios',
        loadComponent: () =>
            import('./pages/usuarios/usuarios.component')
                .then(m => m.UsuariosComponent)
    },
    {
        path: 'criar-usuarios',
        loadComponent: () =>
            import('./pages/usuarios/criar-usuarios/criar-usuarios.component')
                .then(m => m.CriarUsuariosComponent)
    },
    {
        path: 'emprestimos',
        loadComponent: () =>
            import('./pages/emprestimos/emprestimos.component')
                .then(m => m.EmprestimosComponent)
    }
];
