using Biblioteca.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Api.Data;

public class BibliotecaContext : DbContext
{
    public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options){}

    public DbSet<Livro> Livros {get; set;}
    public DbSet<Usuario> Usuarios {get; set;}
    public DbSet<Emprestimo> Emprestimos {get; set;}
}