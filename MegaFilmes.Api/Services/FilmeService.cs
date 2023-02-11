using AutoMapper;
using MegaFilmes.Api.Services.Interfaces;
using MegaFilmes.Domain.Dtos.FilmeDto;
using MegaFilmes.Domain.Entities;
using MegaFilmes.Domain.Interfaces.Repository;
using MegaFilmes.Domain.Validations;

namespace MegaFilmes.Api.Services;

public class FilmeService : IFilmeService
{
    private readonly IFilmeRepository _filmeRepository;
    private readonly IMapper _mapper;

    public FilmeService(IFilmeRepository filmeRepository, IMapper mapper)
    {
        _filmeRepository = filmeRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<ReadFilmeDto>> CreateAsync(CreateFilmeDto filmeDto)
    {
        var resultado = new CreateFilmeValidation().Validate(filmeDto);
        if (resultado.IsValid)
            return ResultService.RequestError<ReadFilmeDto>("Informe um objeto válido", resultado);

        var filme =  _mapper.Map<Filme>(filmeDto);
        var data = await _filmeRepository.CreateAsync(filme);
        return ResultService.Ok(_mapper.Map<ReadFilmeDto>(data), 201);
    }

    public async Task<ResultService> DeleteAsync(int id)
    {
        var filme = await _filmeRepository.GetByIdAsync(id);
        if (filme == null)
            return ResultService.Fail("Filme não encontrado");

        await _filmeRepository.DeleteAsync(filme);
        return ResultService.Ok("Filme removido com sucesso", 204);
    }

    public async Task<ResultService<ICollection<ReadFilmeDto>>> GetAllAsync()
    {
        var filmes = await _filmeRepository.GetAllAsync();
        var data = _mapper.Map<ICollection<ReadFilmeDto>>(filmes);
        return ResultService.Ok(data);
    }

    public async Task<ResultService<ICollection<ReadFilmeDto>>> GetByDirector(string diretor)
    {
        var filmes = await _filmeRepository.GetByDirector(diretor);
        var data = _mapper.Map<ICollection<ReadFilmeDto>>(filmes);
        return ResultService.Ok(data);
    }

    public async Task<ResultService<ICollection<ReadFilmeDto>>> GetByGender(string genero)
    {
        var filmes = await _filmeRepository.GetByGender(genero);
        var data = _mapper.Map<ICollection<ReadFilmeDto>>(filmes);
        return ResultService.Ok(data);
    }

    public async Task<ResultService<ReadFilmeDto>> GetByIdAsync(int id)
    {
        var filme = await _filmeRepository.GetByIdAsync(id);
        if (filme == null)
            return ResultService.Fail<ReadFilmeDto>("Filme não encontrado");
        var data = _mapper.Map<ReadFilmeDto>(filme);
        return ResultService.Ok(data);
    }

    public async Task<ResultService<ICollection<ReadFilmeDto>>> GetByName(string nome)
    {
        var filmes = await _filmeRepository.GetByName(nome);
        var data = _mapper.Map<ICollection<ReadFilmeDto>>(filmes);
        return ResultService.Ok(data);
    }

    public async Task<ResultService<ReadFilmeDto>> UpdateAsync(int id, UpdateFilmeDto filmeDto)
    {
        var resultado = new UpdateFilmeValidation().Validate(filmeDto);
        if (resultado.IsValid)
            return ResultService.RequestError<ReadFilmeDto>("Informe um objeto válido", resultado);

        var filme = await _filmeRepository.GetByIdAsync(id);
        if (filme == null)
            return ResultService.Fail<ReadFilmeDto>("Filme não encontrado");

        filme = _mapper.Map(filmeDto, filme);
        var data = await _filmeRepository.UpdateAsync(filme);
        var readFilmeDto = _mapper.Map<ReadFilmeDto>(data);
        return ResultService.Ok<ReadFilmeDto>(readFilmeDto, 204);
    }
}
