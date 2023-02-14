using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Domain.Interfaces.Repository;

public interface IFilmeRepository
{
    Task<ICollection<Filme>> GetAllAsync(int page, int pageSize);
    Task<Filme?> GetByIdAsync(int id);
    Task<Filme> CreateAsync(Filme filme);
    Task<Filme> UpdateAsync(Filme filme);
    Task DeleteAsync(Filme filme);
    Task<ICollection<Filme>> GetByGender(string genero, int page, int pageSize);
    Task<ICollection<Filme>> GetByDirector(string diretor, int page, int pageSize);
    Task<ICollection<Filme>> GetByName(string nome, int page, int pageSize);
    Task<Filme?> CheckMovieExists(string nome);
    Task<double> GetAverageRatingsAsync(int id);
}
