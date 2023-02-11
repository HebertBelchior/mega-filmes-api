using MegaFilmes.Domain.Dtos.AvaliacaoDto;

namespace MegaFilmes.Api.Services.Interfaces;

public interface IAvaliacaoService
{
    Task<ResultService<ReadAvaliacaoDto>> CreateAsync(CreateAvaliacaoDto avaliacaoDto);
}
