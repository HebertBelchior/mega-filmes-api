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

    public async Task<FilmeAtor?> CheckExists(int atorId, int filmeId, string papel)
    {
        return await _db.FilmesAtores.FirstOrDefaultAsync(x => x.AtorId == atorId && x.FilmeId == filmeId && x.Papel == papel);
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
        await _db.FilmesAtores.Include(f => f.Filme).Include(fa => fa.Ator).ToListAsync();
        return await _db.FilmesAtores.ToListAsync();
    }

    public async Task<FilmeAtor?> GetByAtorId(int id)
    {
        await _db.FilmesAtores.Include(f => f.Filme).Include(fa => fa.Ator).FirstOrDefaultAsync(f => f.Id == id);
        return await _db.FilmesAtores.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<FilmeAtor?> GetByFilmeId(int id)
    {
        await _db.FilmesAtores.Include(f => f.Filme).Include(fa => fa.Ator).FirstOrDefaultAsync(f => f.Id == id);
        return await _db.FilmesAtores.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<FilmeAtor?> GetByIdAsync(int id)
    {
        await _db.FilmesAtores.Include(f => f.Filme).Include(fa => fa.Ator).FirstOrDefaultAsync(f => f.Id == id);
        return await _db.FilmesAtores.FirstOrDefaultAsync(x => x.Id == id);
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
