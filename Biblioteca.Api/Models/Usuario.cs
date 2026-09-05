namespace Biblioteca.Api.Models;
public class Usuario
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public int Tefone {get; set;}
    public ICollection<Emprestimo> Emprestimos {get; set;} = new List<Emprestimo>();
}