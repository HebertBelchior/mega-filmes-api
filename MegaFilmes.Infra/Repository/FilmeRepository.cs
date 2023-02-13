using MegaFilmes.Domain.Entities;
using MegaFilmes.Domain.Interfaces.Repository;
using MegaFilmes.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace MegaFilmes.Infra.Repository;

public class FilmeRepository : IFilmeRepository
{
    private readonly AppDbContext _db;

    public FilmeRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Filme?> CheckMovieExists(string nome)
    {
        return await _db.Filmes.FirstOrDefaultAsync(x => x.Nome.ToLower() == nome.ToLower());
    }

    public async Task<Filme> CreateAsync(Filme filme)
    {
        _db.Add(filme);
        await _db.SaveChangesAsync();
        return filme;
    }

    public async Task DeleteAsync(Filme filme)
    {
        _db.Remove(filme);
        await _db.SaveChangesAsync();
    }

    public async Task<ICollection<Filme>> GetAllAsync()
    {
        return await _db.Filmes.ToListAsync();
    }

    public async Task<ICollection<Filme>> GetByDirector(string diretor)
    {
        return await _db.Filmes
            .Where(x => x.Diretor.Contains(diretor))
            .ToListAsync();
    }

    public async Task<ICollection<Filme>> GetByGender(string genero)
    {
        return await _db.Filmes
            .Where(x => x.Genero == genero)
            .ToListAsync();
    }

    public async Task<Filme?> GetByIdAsync(int id)
    {
        return await _db.Filmes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Filme>> GetByName(string nome)
    {
        return await _db.Filmes
            .Where(x => x.Nome.Contains(nome))
            .ToListAsync();
    }

    public async Task<Filme> UpdateAsync(Filme filme)
    {
        _db.Update(filme);
        await _db.SaveChangesAsync();
        return filme;
    }

    public async Task<double> GetAverageRatingsAsync(int id)
    {
        var filme = await _db.Filmes
            .Include(f => f.Avaliacao)
            .SingleOrDefaultAsync(f => f.Id == id);

        var media = filme.Avaliacao.Average(a => a.Criterio);

        return Math.Round(media, 1);
    }
}
