namespace MegaFilmes.Domain.Dtos.FilmeDto;

public class FilmeFilterDto : PagedBaseRequest
{
    public string? Nome { get; set; }
    public string? Genero { get; set; }
    public string? Diretor { get; set; }
}
