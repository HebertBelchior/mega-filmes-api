using MegaFilmes.Domain.Dtos;
using MegaFilmes.Domain.Dtos.FilmeDto;
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

    public async Task<PagedBaseResponse<ReadFilmeDto>> GetAllAsync(int pageNumber, int pageSize)
    {
        var count = await _db.Filmes.AsQueryable().CountAsync();

        var filmes = await _db.Filmes
            .Include(x => x.Genero)
            .Include(x => x.Avaliacao)
            .Include(f => f.FilmesAtores)
            .ThenInclude(fa => fa.Ator)
            .Select(x => new ReadFilmeDto {
                Id = x.Id,
                Nome = x.Nome,
                Descricao = x.Descricao,
                Ano = x.Ano,
                Diretor = x.Diretor,
                Genero = x.Genero.Nome,
                AvaliacaoMedia = x.Avaliacao.Count() > 0 ? Math.Round(x.Avaliacao.Average(a => a.Criterio), 1) : 0,
                Elenco = x.FilmesAtores.
             })
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedBaseResponse<ReadFilmeDto>
        {
            Data = filmes,
            TotalRegisters = count,
            TotalPages = (int)Math.Ceiling((double)count / pageSize)
        };
        return await _db.Filmes.Include(f => f.FilmesAtores).ThenInclude(fa => fa.Ator).ToListAsync();
    }

    public async Task<PagedBaseResponse<ReadFilmeDto>> GetByDirector(string diretor, int pageNumber, int pageSize)
    {
        var count = await _db.Filmes.AsQueryable().CountAsync();
        var filmes = await _db.Filmes
            .Include(x => x.Genero)
            .Include(x => x.Avaliacao)
        return await _db.Filmes.Include(a => a.FilmesAtores).ThenInclude(fa => fa.Ator)
            .Where(x => x.Diretor.Contains(diretor))
            .Select(x => new ReadFilmeDto {
                Id = x.Id,
                Nome = x.Nome,
                Descricao = x.Descricao,
                Ano = x.Ano,
                Diretor = x.Diretor,
                Genero = x.Genero.Nome,
                AvaliacaoMedia = x.Avaliacao.Count() > 0 ? Math.Round(x.Avaliacao.Average(a => a.Criterio), 1) : 0,
             })
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedBaseResponse<ReadFilmeDto>
        {
            Data = filmes,
            TotalRegisters = count,
            TotalPages = (int)Math.Ceiling((double)count / pageSize)
        };
    }

    public async Task<PagedBaseResponse<ReadFilmeDto>> GetByGender(string genero, int pageNumber, int pageSize)
    {
        var filmes = await _db.Filmes
            .Include(x => x.Genero)
            .Include(x => x.Avaliacao)
            .Where(x => x.Genero.Nome.ToLower() == genero.ToLower())
            .Select(x => new ReadFilmeDto {
                Id = x.Id,
                Nome = x.Nome,
                Descricao = x.Descricao,
                Ano = x.Ano,
                Diretor = x.Diretor,
                Genero = x.Genero.Nome,
                AvaliacaoMedia = x.Avaliacao.Count() > 0 ? Math.Round(x.Avaliacao.Average(a => a.Criterio ),1) : 0,
            })
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
        return await _db.Filmes.Include(a => a.FilmesAtores).ThenInclude(fa => fa.Ator)
            .Where(x => x.Genero == genero)
            .ToListAsync();

        var count = await _db.Filmes
            .Where(x => x.Genero.Nome == genero).CountAsync();

        return new PagedBaseResponse<ReadFilmeDto>
        {
            Data = filmes,
            TotalRegisters = count,
            TotalPages = (int)Math.Ceiling((double)count / pageSize)
        };
    }

    public async Task<Filme?> GetByIdAsync(int id)
    {
        return await _db.Filmes.Include(a => a.FilmesAtores).ThenInclude(fa => fa.Ator).FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<PagedBaseResponse<ReadFilmeDto>> GetByName(string nome, int pageNumber, int pageSize)
    {
        var filmes = await _db.Filmes
            .Include(x => x.Genero)
            .Include(x => x.Avaliacao)
        return await _db.Filmes.Include(a => a.FilmesAtores).ThenInclude(fa => fa.Ator)
            .Where(x => x.Nome.Contains(nome))
            .Select(x => new ReadFilmeDto {
                 Id = x.Id,
                 Nome = x.Nome,
                 Descricao = x.Descricao,
                 Ano = x.Ano,
                 Diretor = x.Diretor,
                 Genero = x.Genero.Nome,
                 AvaliacaoMedia = x.Avaliacao.Count() > 0 ? Math.Round(x.Avaliacao.Average(a => a.Criterio), 1) : 0,
             })
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await _db.Filmes
            .Where(x => x.Nome.Contains(nome)).CountAsync();

        return new PagedBaseResponse<ReadFilmeDto>
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
