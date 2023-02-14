using MegaFilmes.Domain.Dtos;
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

    public async Task<PagedBaseResponse<Filme>> GetAllAsync(int pageNumber, int pageSize)
    {
        var count = await _db.Filmes.AsQueryable().CountAsync();

        var filmes = await _db.Filmes
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedBaseResponse<Filme>
        {
            Data = filmes,
            TotalRegisters = count,
            TotalPages = (int)Math.Ceiling((double)count / pageSize)
        };
    }

    public async Task<PagedBaseResponse<Filme>> GetByDirector(string diretor, int pageNumber, int pageSize)
    {
        var count = await _db.Filmes.AsQueryable().CountAsync();
        var filmes = await _db.Filmes
            .Where(x => x.Diretor.Contains(diretor))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedBaseResponse<Filme>
        {
            Data = filmes,
            TotalRegisters = count,
            TotalPages = (int)Math.Ceiling((double)count / pageSize)
        };
    }

    public async Task<PagedBaseResponse<Filme>> GetByGender(string genero, int pageNumber, int pageSize)
    {
        var filmes = await _db.Filmes
            .Where(x => x.Genero == genero)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await _db.Filmes
            .Where(x => x.Genero == genero).CountAsync();

        return new PagedBaseResponse<Filme>
        {
            Data = filmes,
            TotalRegisters = count,
            TotalPages = (int)Math.Ceiling((double)count / pageSize)
        };
    }

    public async Task<Filme?> GetByIdAsync(int id)
    {
        return await _db.Filmes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<PagedBaseResponse<Filme>> GetByName(string nome, int pageNumber, int pageSize)
    {
        var count = await _db.Filmes.AsQueryable().CountAsync();
        var filmes = await _db.Filmes
            .Where(x => x.Nome.Contains(nome))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedBaseResponse<Filme>
        {
            Data = filmes,
            TotalRegisters = count,
            TotalPages = (int)Math.Ceiling((double)count / pageSize)
        };
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
