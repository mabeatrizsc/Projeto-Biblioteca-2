using Biblioteca.Api.Dtos;
using Biblioteca.Api.Models;

namespace Biblioteca.Api.Services;

public interface IEmprestimoService
{
    Task<List<Emprestimo>> GetEmprestimosAsync();
    Task<Emprestimo?> GetEmprestimoByIdAsync(int id);
    Task<Emprestimo> CreateEmprestimoAsync(EmprestimoCreateDto dto);
    Task<Emprestimo> DevolverLivroAsync(int emprestimoId);
}