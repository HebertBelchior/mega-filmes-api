using MegaFilmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaFilmes.Domain.Interfaces.Repository
{
    public interface IAtorRepository
    {
        Task<ICollection<Ator>> GetAllAsync();
        Task<Ator?> GetByIdAsync(int id);
        Task<Ator> CreateAsync(Ator ator);
        Task<Ator> UpdateAsync(Ator ator);
        Task DeleteAsync(Ator ator);
        Task<IEnumerable<Ator?>> GetByName(string nome);
    }
}
