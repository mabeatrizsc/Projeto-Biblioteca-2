namespace Biblioteca.Api.Dtos;

public class EmprestimoCreateDto
{
    public int UsuarioId {get; set;}
    public int LivroId {get; set;}
    public int PrazoDias {get; set;}
}