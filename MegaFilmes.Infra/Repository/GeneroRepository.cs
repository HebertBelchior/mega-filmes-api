using MegaFilmes.Domain.Entities;
using MegaFilmes.Domain.Interfaces.Repository;
using MegaFilmes.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace MegaFilmes.Infra.Repository;

public class GeneroRepository : IGeneroRepository
{
    private readonly AppDbContext _db;

    public GeneroRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Genero> CheckGenderExists(string gender)
    {
        return await _db.Generos.FirstOrDefaultAsync(g => g.Nome == gender);
    }

    public async Task<Genero> CreateAync(Genero genero)
    {
        _db.Add(genero);
        await _db.SaveChangesAsync();
        return genero;
    }

    public async Task<ICollection<Genero>> GetAllAsync()
    {
        return await _db.Generos.ToListAsync();
    }
}
