using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Domain.Interfaces.Repository;

public interface IFilmeAtorRepository
{
    Task<ICollection<FilmeAtor>> GetAllAsync();
    Task<FilmeAtor?> GetByIdAsync(int id);
    Task<FilmeAtor> CreateAsync(FilmeAtor filmeAtor);
    Task<FilmeAtor> UpdateAsync(FilmeAtor filmeAtor);
    Task DeleteAsync(FilmeAtor filmeAtor);
}
