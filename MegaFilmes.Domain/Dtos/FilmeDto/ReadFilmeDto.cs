namespace MegaFilmes.Domain.Dtos.FilmeDto;

public class ReadFilmeDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Ano { get; set; }
    public string Diretor { get; set; }
    public string Genero { get; set; }
    public List<ElencoDto> Elenco { get; set; }
}
