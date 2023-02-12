using MegaFilmes.Api.Services.Interfaces;
using MegaFilmes.Domain.Dtos.AvaliacaoDto;

namespace MegaFilmes.Api.Services;

public class AvaliacaoService : IAvaliacaoService
{
    private readonly IAvaliacaoRepository _avaliacaoRepository;
    public Task<ResultService<ReadAvaliacaoDto>> CreateAsync(CreateAvaliacaoDto avaliacaoDto)
    {

    }
}
