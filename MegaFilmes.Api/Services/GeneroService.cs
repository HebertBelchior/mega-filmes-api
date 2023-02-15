using AutoMapper;
using MegaFilmes.Api.Services.Interfaces;
using MegaFilmes.Domain.Dtos.GeneroDto;
using MegaFilmes.Domain.Entities;
using MegaFilmes.Domain.Interfaces.Repository;
using MegaFilmes.Domain.Validations;

namespace MegaFilmes.Api.Services;

public class GeneroService : IGeneroService
{
    private readonly IGeneroRepository _generoRepository;
    private readonly IMapper _mapper;

    public GeneroService(IGeneroRepository generoRepository, IMapper mapper)
    {
        _generoRepository = generoRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<ReadGeneroDto>> CreateAsync(CreateGeneroDto generoDto)
    {
        var resultado = new CreateGeneroValidation().Validate(generoDto);
        if (!resultado.IsValid)
            return ResultService.RequestError<ReadGeneroDto>("Informe um objeto válido", resultado);

        var generoExiste = await _generoRepository.CheckGenderExists(generoDto.Nome);
        if (generoExiste != null)
            return ResultService.Fail<ReadGeneroDto>("Já existe um genero cadastrado com esse nome", 409);

        var genero = _mapper.Map<Genero>(generoDto);
        var data = await _generoRepository.CreateAync(genero);
        return ResultService.Ok(_mapper.Map<ReadGeneroDto>(data), 201);
    }

    public async Task<ResultService<ICollection<ReadGeneroDto>>> GetAllAsync()
    {
        var generos = await _generoRepository.GetAllAsync();
        var data = _mapper.Map<ICollection<ReadGeneroDto>>(generos);
        return ResultService.Ok(data);
    }
}
