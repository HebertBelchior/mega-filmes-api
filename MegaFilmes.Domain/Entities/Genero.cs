namespace MegaFilmes.Domain.Entities;

public class Genero
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<Filme> Filme { get; set; }
}
