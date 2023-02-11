using System.ComponentModel.DataAnnotations;

namespace MegaFilmes.Domain.Dtos.FilmeDto;

public class CreateFilmeDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Ano { get; set; }
    public string Diretor { get; set; }
    public string Genero { get; set; }
}
