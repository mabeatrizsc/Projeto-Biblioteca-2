using Biblioteca.Api.Models;

namespace Biblioteca.Api.Services;

public interface IUsuarioService
{
    Task<List<Usuario>> GetUsuariosAsync();
    Task<Usuario?> GetUsuarioById(int id);
    Task<Usuario> CreateUsuarioAsync(Usuario usuario);
    Task<bool> UpdateUsuarioAsync(int id, Usuario usuario);
    Task<bool> DeleteUsuarioAsync(int id);
}