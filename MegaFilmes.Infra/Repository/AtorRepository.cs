using MegaFilmes.Domain.Entities;
using MegaFilmes.Domain.Interfaces.Repository;
using MegaFilmes.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace MegaFilmes.Infra.Repository;

public class AtorRepository : IAtorRepository
{
    private readonly AppDbContext _db;

    public AtorRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Ator> CreateAsync(Ator ator)
    {
        _db.Add(ator);
        await _db.SaveChangesAsync();
        return ator;
    }

    public async Task DeleteAsync(Ator ator)
    {
        _db.Remove(ator);
        await _db.SaveChangesAsync();
    }

    public async Task<ICollection<Ator>> GetAllAsync()
    {
        return await _db.Atores.ToListAsync();
    }

    public async Task<Ator?> GetByIdAsync(int id)
    {
        return await _db.Atores.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Ator?>> GetByName(string nome)
    {
        return await _db.Atores
        .Where(x => EF.Functions.Like(x.Nome, $"%{nome}%"))
        .ToListAsync();
    }

    public async Task<Ator> UpdateAsync(Ator ator)
    {
        _db.Update(ator);
        await _db.SaveChangesAsync();
        return ator;
    }
}
