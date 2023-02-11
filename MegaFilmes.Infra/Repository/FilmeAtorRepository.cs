
using MegaFilmes.Domain.Entities;
using MegaFilmes.Domain.Interfaces.Repository;
using MegaFilmes.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace MegaFilmes.Infra.Repository;

public class FilmeAtorRepository : IFilmeAtorRepository
{
    private readonly AppDbContext _db;

    public FilmeAtorRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<FilmeAtor> CreateAsync(FilmeAtor filmeAtor)
    {
        _db.Add(filmeAtor);
        await _db.SaveChangesAsync();
        return filmeAtor;
    }

    public async Task DeleteAsync(FilmeAtor filmeAtor)
    {
        _db.Remove(filmeAtor);
        await _db.SaveChangesAsync();
    }

    public async Task<ICollection<FilmeAtor>> GetAllAsync()
    {
        return await _db.FilmesAtores.ToListAsync();
    }

    public async Task<FilmeAtor?> GetByIdAsync(int id)
    {
        return await _db.FilmesAtores.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<FilmeAtor> UpdateAsync(FilmeAtor filmeAtor)
    {
        _db.Update(filmeAtor);
        await _db.SaveChangesAsync();
        return filmeAtor;
    }
}
