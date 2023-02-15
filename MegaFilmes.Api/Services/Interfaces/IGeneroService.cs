using MegaFilmes.Domain.Dtos.GeneroDto;
using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Api.Services.Interfaces;

public interface IGeneroService
{
    Task<ResultService<ReadGeneroDto>> CreateAsync(CreateGeneroDto generoDto);
    Task<ResultService<ICollection<ReadGeneroDto>>> GetAllAsync();
}
