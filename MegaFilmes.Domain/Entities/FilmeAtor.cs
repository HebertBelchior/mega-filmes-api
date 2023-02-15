using System.ComponentModel.DataAnnotations.Schema;

namespace MegaFilmes.Domain.Entities;

public class FilmeAtor
{
    public int Id { get; set; }
    public string Papel { get; set; }

    public int FilmeId { get; set; }
    [ForeignKey(nameof(FilmeId))]
    public Filme Filme { get; set; }
    public int AtorId { get; set; }
    [ForeignKey(nameof(AtorId))]
    public Ator Ator { get; set; }
}
