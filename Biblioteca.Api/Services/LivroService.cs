using Biblioteca.Api.Data;
using Biblioteca.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Api.Services;

public class LivroService : ILivroService
{
    private readonly BibliotecaContext _context;

    public LivroService(BibliotecaContext context)
    {
        _context = context;
    }
    public async Task<Livro> CreateLivroAsync(Livro livro)
    {
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
        return livro;
    }

    public async Task<bool> DeleteLivroAsync(int id)
    {
        var livro = await _context.Livros.FindAsync(id);
        if(livro == null)
            return false;
        
        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Livro?> GetLivroById(int id)
    {
         return await _context.Livros.FindAsync(id);
    }

    public async Task<List<Livro>> GetLivrosAsync()
    {
        return await _context.Livros.ToListAsync();
    }

    public async Task<bool> UpdateLivroAsync(int id, Livro livro)
    {
       var livroExiste = await _context.Livros.FindAsync(id);
        if(livro == null)
            return false;
        
        livroExiste.Titulo = livro.Titulo;
        livroExiste.Autor = livro.Autor;
        livroExiste.AnoPublicacao = livro.AnoPublicacao;

        await _context.SaveChangesAsync();

        return true;
    }
}