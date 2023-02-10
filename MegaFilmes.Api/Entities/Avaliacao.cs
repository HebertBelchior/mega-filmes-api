namespace MegaFilmes.Api.Entities;

public class Avaliacao
{
    public int Id { get; set; }
    public int Criterio { get; set; }
    public string Comentario { get; set; }
    public int FilmeId { get; set; }
    public Filme Filme { get; set; }
}
