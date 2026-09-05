using Biblioteca.Api.Models;

namespace Biblioteca.Api.Services;

public interface ILivroService
{
    Task<List<Livro>> GetLivrosAsync();
    Task<Livro?> GetLivroById(int id);
    Task<Livro> CreateLivroAsync(Livro livro);
    Task<bool> UpdateLivroAsync(int id, Livro livro);
    Task<bool> DeleteLivroAsync(int id);
}