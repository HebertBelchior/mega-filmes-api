using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Domain.Interfaces.Repository;

public interface IAvaliacaoRepository
{
    Task<ICollection<Avaliacao>> GetAllAsync();
    Task<Avaliacao?> GetByIdAsync(int id);
    Task<Avaliacao> CreateAsync (Avaliacao avaliacao);
    Task<Avaliacao> UpadateAsync (Avaliacao avaliacao);
    Task DeleteAsync(Avaliacao avaliacao);
}
