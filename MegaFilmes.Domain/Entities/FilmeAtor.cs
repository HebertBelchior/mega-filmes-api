namespace MegaFilmes.Domain.Entities;

public class FilmeAtor
{
    public int Id { get; set; }
    public int FilmeId { get; set; }
    public Filme Filme { get; set; }
    public int AtorId { get; set; }
    public Ator Ator { get; set; }
    public string Papel { get; set; }
}
