using Biblioteca.Api.Models;
using Biblioteca.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;
    public  UsuarioController(IUsuarioService service)
    {
        _service = service;
    }

     [HttpGet]
    public async Task<ActionResult<List<Usuario>>> GetAllUsuario()
    {
        return Ok(await _service.GetUsuariosAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetById(int id)
    {
        var usuario = await _service.GetUsuarioById(id);
        if (usuario == null)
            return NotFound();
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<ActionResult<Usuario>> Create(Usuario usuario)
    {
        var novoUsuario = await _service.CreateUsuarioAsync(usuario);

        return CreatedAtAction(
            nameof(GetById),
            new { id = novoUsuario.Id},
            novoUsuario     
        );
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Usuario>> Update(int id, Usuario usuario)
    {
        var usuarioAtualizado = await _service.UpdateUsuarioAsync(id, usuario);
        if (!usuarioAtualizado)
            return NotFound();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<Usuario>> Delete(int id)
    {
        var usuarioRemovido = await _service.DeleteUsuarioAsync(id);
        if (!usuarioRemovido)
            return NotFound();
        return NoContent();
    }
}