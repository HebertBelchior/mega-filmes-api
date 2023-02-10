using MegaFilmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaFilmes.Domain.Interfaces.Repository
{
    public interface IFilmeAtorRepository
    {
        Task<ICollection<FilmeAtor>> GetAllAsync();
        Task<FilmeAtor?> GetByIdAsync(int id);
        Task<FilmeAtor> CreateAsync(FilmeAtor filmeAtor);
        Task<FilmeAtor> UpdateAsync(FilmeAtor filmeAtor);
        Task DeleteAsync(FilmeAtor filmeAtor);
    }
}
