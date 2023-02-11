using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Domain.Interfaces.Repository;

public interface IFilmeRepository
{
    Task<ICollection<Filme>> GetAllAsync();
    Task<Filme?> GetByIdAsync(int id);
    Task<Filme> CreateAsync(Filme filme);
    Task<Filme> UpdateAsync(Filme filme);
    Task DeleteAsync(Filme filme);
    Task<ICollection<Filme>> GetByGender(string genero);
    Task<ICollection<Filme>> GetByDirector(string diretor);
    Task<ICollection<Filme>> GetByName(string nome);
}
