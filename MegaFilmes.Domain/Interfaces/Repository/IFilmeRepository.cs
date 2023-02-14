﻿using MegaFilmes.Domain.Dtos;
using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Domain.Interfaces.Repository;

public interface IFilmeRepository
{
    Task<PagedBaseResponse<Filme>> GetAllAsync(int page, int pageSize);
    Task<Filme?> GetByIdAsync(int id);
    Task<Filme> CreateAsync(Filme filme);
    Task<Filme> UpdateAsync(Filme filme);
    Task DeleteAsync(Filme filme);
    Task<PagedBaseResponse<Filme>> GetByGender(string genero, int page, int pageSize);
    Task<PagedBaseResponse<Filme>> GetByDirector(string diretor, int page, int pageSize);
    Task<PagedBaseResponse<Filme>> GetByName(string nome, int page, int pageSize);
    Task<Filme?> CheckMovieExists(string nome);
    Task<double> GetAverageRatingsAsync(int id);
}
