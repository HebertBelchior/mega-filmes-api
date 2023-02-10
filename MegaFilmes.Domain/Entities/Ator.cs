namespace MegaFilmes.Domain.Entities;

public class Ator
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<FilmeAtor> FilmesAtores { get; set; }
}
