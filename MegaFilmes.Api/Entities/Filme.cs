namespace MegaFilmes.Api.Entities;

public class Filme
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Ano { get; set; }
    public string Diretor { get; set; }
    public string Genero { get; set; }
    public ICollection<Avaliacao> Avaliacao { get; set; }
    public ICollection<FilmeAtor> FilmesAtores { get; set; }
}
