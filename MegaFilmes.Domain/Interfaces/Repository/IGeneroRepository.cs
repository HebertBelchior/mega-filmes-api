using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Domain.Interfaces.Repository;

public interface IGeneroRepository
{
    Task<Genero> CreateAync(Genero filme);
    Task<ICollection<Genero>> GetAllAsync();
}
