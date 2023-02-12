namespace MegaFilmes.Domain.Dtos.AvaliacaoDto;

public class CreateAvaliacaoDto
{
    public int Criterio { get; set; }
    public string? Comentario { get; set; }
    public int FilmeId { get; set; }
}
