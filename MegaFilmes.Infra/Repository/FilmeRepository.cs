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

    public async Task<IEnumerable<Filme?>> GetByDirector(string diretor)
    {
        return await _db.Filmes
            .Where(x => EF.Functions.Like(x.Diretor, $"%{diretor}%"))
            .ToListAsync();
    }

    public async Task<Filme?> GetByGender(string genero)
    {
        return await _db.Filmes.FirstOrDefaultAsync(x => x.Genero == genero);
    }

    public async Task<Filme?> GetByIdAsync(int id)
    {
        return await _db.Filmes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Filme?>> GetByName(string nome)
    {
        return await _db.Filmes
            .Where(x => EF.Functions.Like(x.Nome, $"%{nome}%"))
            .ToListAsync();
    }

    public async Task<Filme> UpdateAsync(Filme filme)
    {
        _db.Update(filme);
        await _db.SaveChangesAsync();
        return filme;
    }
}
