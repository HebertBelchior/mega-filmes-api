namespace MegaFilmes.Api.Entities;

public class Ator
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<Filme> Filmes { get; set; }
    public ICollection<FilmesAtores> FilmesAtores { get; set; }

}
