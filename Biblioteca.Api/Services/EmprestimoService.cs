using Biblioteca.Api.Data;
using Biblioteca.Api.Dtos;
using Biblioteca.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Api.Services;

public class EmprestimoService : IEmprestimoService
{
    private readonly BibliotecaContext _context;
    public EmprestimoService(BibliotecaContext context)
    {
        _context = context;
    }
    public async Task<List<Emprestimo>> GetEmprestimosAsync()
    {
        return await _context.Emprestimos
            .Include(e => e.Usuario)
            .Include(e => e.Livro)
            .ToListAsync();
    }
    public async Task<Emprestimo?> GetEmprestimoByIdAsync(int id)
    {
        return await _context.Emprestimos
            .Include(e => e.Usuario)
            .Include(e => e.Livro)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
    public async Task<Emprestimo> CreateEmprestimoAsync(EmprestimoCreateDto dto)
    {
        if(dto.PrazoDias != 7 || dto.PrazoDias != 14 || dto.PrazoDias != 21)
        {
            throw new Exception("O prazo de devolução deve ser 7, 14 ou 21 dias."); 
        }
        var usuario = await _context.Usuarios
            .FindAsync(dto.UsuarioId);
        if (usuario == null)
            throw new Exception("Usuário não encontrado.");
        var livro = await _context.Livros
            .FindAsync(dto.LivroId);

        if (livro == null)
            throw new Exception("Livro não encontrado.");

        var emprestimoAtivo = await _context.Emprestimos
            .AnyAsync(e =>
                e.LivroId == dto.LivroId &&
                e.DataDevolucao == null);

        if (emprestimoAtivo)
            throw new Exception("O livro já está emprestado.");

    var dataEmprestimo = DateTime.Now;
    var emprestimo = new Emprestimo
    {
        UsuarioId = dto.UsuarioId,
        LivroId = dto.LivroId,
        DataEmprestimo = dataEmprestimo,
        DataPrevistaDevolucao =
            dataEmprestimo.AddDays(dto.PrazoDias),
        DataDevolucao = null
    };

    _context.Emprestimos.Add(emprestimo);

        await _context.SaveChangesAsync();
        return emprestimo;
    }

    public async Task<Emprestimo> DevolverLivroAsync(int emprestimoId)
    {
        var emprestimo = await _context.Emprestimos
            .FindAsync(emprestimoId);

        if (emprestimo == null)
            throw new Exception("Empréstimo não encontrado.");

        if (emprestimo.DataDevolucao != null)
            throw new Exception("Este livro já foi devolvido.");

        emprestimo.DataDevolucao = DateTime.Now;
        await _context.SaveChangesAsync();
        return emprestimo;
    }
}