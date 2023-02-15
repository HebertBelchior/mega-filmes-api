using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Domain.Dtos.FilmeAtorDto;

public class ReadFilmeAtorDto
{
    public int Id { get; set; }
    public int FilmeId { get; set; }
    public string Filme { get; set; }
    public int AtorId { get; set; }
    public string Ator { get; set; }
    public string Papel { get; set; }
}
