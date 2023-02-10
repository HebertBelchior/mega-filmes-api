using MegaFilmes.Domain.Entities;
using MegaFilmes.Domain.Interfaces.Repository;
using MegaFilmes.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace MegaFilmes.Infra.Repository
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly AppDbContext _db;

        public AvaliacaoRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Avaliacao> CreateAsync(Avaliacao avaliacao)
        {
            _db.Add(avaliacao);
            await _db.SaveChangesAsync();
            return avaliacao;
        }

        public async Task DeleteAsync(Avaliacao avaliacao)
        {
            _db.Remove(avaliacao);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<Avaliacao>> GetAllAsync()
        {
            return await _db.Avaliacoes.ToListAsync();
        }

        public async Task<Avaliacao?> GetByIdAsync(int id)
        {
            return await _db.Avaliacoes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Avaliacao> UpadateAsync(Avaliacao avaliacao)
        {
            _db.Update(avaliacao);
            await _db.SaveChangesAsync();
            return avaliacao;
        }
    }
}
