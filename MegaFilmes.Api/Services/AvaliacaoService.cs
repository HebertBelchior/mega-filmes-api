using AutoMapper;
using MegaFilmes.Api.Services.Interfaces;
using MegaFilmes.Domain.Dtos.AvaliacaoDto;
using MegaFilmes.Domain.Entities;
using MegaFilmes.Domain.Interfaces.Repository;
using MegaFilmes.Domain.Validations;

namespace MegaFilmes.Api.Services;

public class AvaliacaoService : IAvaliacaoService
{
    private readonly IAvaliacaoRepository _avaliacaoRepository;
    private readonly IFilmeRepository _filmerepository;
    private readonly IMapper _mapper;
    public AvaliacaoService(IAvaliacaoRepository avaliacaoRepository, IMapper mapper, IFilmeRepository filmerepository)
    {
        _avaliacaoRepository = avaliacaoRepository;
        _filmerepository = filmerepository;
        _mapper = mapper;
    }

    public async Task<ResultService<ReadAvaliacaoDto>> CreateAsync(CreateAvaliacaoDto avaliacaoDto)
    {
        var resultado = new CreateAvaliacaoValidation().Validate(avaliacaoDto);
        if (!resultado.IsValid)
            return ResultService.RequestError<ReadAvaliacaoDto>("Informe um objeto válido", resultado);

        var avaliacaoExiste = await _filmerepository.GetByIdAsync(avaliacaoDto.FilmeId);
        if (avaliacaoExiste == null)
            return ResultService.Fail<ReadAvaliacaoDto>("Nao existe filme com o id informado");

        var avaliacao = _mapper.Map<Avaliacao>(avaliacaoDto);
        var data = await _avaliacaoRepository.CreateAsync(avaliacao);
        return ResultService.Ok(_mapper.Map<ReadAvaliacaoDto>(data), 201);
    }
}
