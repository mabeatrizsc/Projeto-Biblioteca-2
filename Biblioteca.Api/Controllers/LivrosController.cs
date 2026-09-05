using Biblioteca.Api.Models;
using Biblioteca.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivrosController : ControllerBase
{
    private readonly ILivroService _service;
    public LivrosController(ILivroService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Livro>>> GetAllLivro()
    {
        return Ok(await _service.GetLivrosAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Livro>> GetById(int id)
    {
        var livro = await _service.GetLivroById(id);
        if (livro == null)
            return NotFound();
        return Ok(livro);
    }

    [HttpPost]
    public async Task<ActionResult<Livro>> Create(Livro livro)
    {
        var novolivro = await _service.CreateLivroAsync(livro);

        return CreatedAtAction(
            nameof(GetById),
            new { id = novolivro.Id},
            novolivro     
        );
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Livro>> Update(int id, Livro livro)
    {
        var livroAtualizado = await _service.UpdateLivroAsync(id, livro);
        if (!livroAtualizado)
            return NotFound();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<Livro>> Delete(int id)
    {
        var livroRemovido = await _service.DeleteLivroAsync(id);
        if (!livroRemovido)
            return NotFound();
        return NoContent();
    }
}