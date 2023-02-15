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

    public async Task<FilmeAtor?> CheckExists(int atorId, int filmeId)
    {
        return await _db.FilmesAtores.FirstOrDefaultAsync(x => x.AtorId == atorId && x.FilmeId == filmeId);
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
        return await _db.FilmesAtores.Include(f => f.Filme).Include(fa => fa.Ator).ToListAsync();
    }

    public async Task<FilmeAtor?> GetByAtorId(int id)
    {
        return await _db.FilmesAtores.Include(f => f.Filme).Include(fa => fa.Ator).FirstOrDefaultAsync(f => f.AtorId == id);
    }

    public async Task<FilmeAtor?> GetByFilmeId(int id)
    {
        return await _db.FilmesAtores.Include(f => f.Filme).Include(fa => fa.Ator).FirstOrDefaultAsync(f => f.FilmeId == id);
    }

    public async Task<FilmeAtor?> GetByIdAsync(int id)
    {
        return await _db.FilmesAtores.Include(f => f.Filme).Include(fa => fa.Ator).FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<ICollection<FilmeAtor>> GetByPapel(string papel)
    {
        return await _db.FilmesAtores.Include(f => f.Filme).Include(fa => fa.Ator).Where(x => x.Papel.Contains(papel)).ToListAsync();
    }

    public async Task<FilmeAtor> UpdateAsync(FilmeAtor filmeAtor)
    {
        _db.Update(filmeAtor);
        await _db.SaveChangesAsync();
        return filmeAtor;
    }
}
