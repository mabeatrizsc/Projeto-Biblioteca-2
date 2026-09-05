using Biblioteca.Api.Data;
using Biblioteca.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Api.Services;

public class UsuarioService : IUsuarioService
{
    private readonly BibliotecaContext _context;

    public UsuarioService(BibliotecaContext context)
    {
        _context = context;
    }

    public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
    {
         _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<bool> DeleteUsuarioAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if(usuario == null)
            return false;
        
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Usuario?> GetUsuarioById(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<List<Usuario>> GetUsuariosAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<bool> UpdateUsuarioAsync(int id, Usuario usuario)
    {
        var usuarioExiste = await _context.Usuarios.FindAsync(id);
        if(usuario == null)
            return false;
        
        usuarioExiste.Nome = usuario.Nome;
        usuarioExiste.Email = usuario.Email;
        usuarioExiste.Tefone = usuario.Tefone;

        await _context.SaveChangesAsync();

        return true;
    }
}