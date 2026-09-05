using Biblioteca.Api.Dtos;
using Biblioteca.Api.Models;
using Biblioteca.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmprestimoController : ControllerBase
{
    private readonly IEmprestimoService _service;
    public  EmprestimoController(IEmprestimoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Emprestimo>>> GetEmprestimos()
    {
        var emprestimo = await _service.GetEmprestimosAsync();
        return Ok(emprestimo);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Emprestimo>> GetEmprestimo(int id)
    {
        var emprestimo = await _service.GetEmprestimoByIdAsync(id);

        if(emprestimo == null)
            return NotFound("Empréstimo não encontrado.");
        
        return Ok(emprestimo);
    }
    [HttpPost]
    public async Task<ActionResult<Emprestimo>> CreateEmprestimo(EmprestimoCreateDto dto)
    {
        try
        {
            var novoEmprestimo = await _service.CreateEmprestimoAsync(dto);

            return CreatedAtAction(
                nameof(GetEmprestimo),
                new { id = novoEmprestimo.Id},
                novoEmprestimo
            );
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("{id}/devolver")]
    public async Task<ActionResult<Emprestimo>> DevolverLivro(int id)
    {
        try
        {
            var emprestimo = await _service.DevolverLivroAsync(id);

            return Ok(emprestimo);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

