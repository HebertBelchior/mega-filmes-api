using AutoMapper;
using MegaFilmes.Api.Services.Interfaces;
using MegaFilmes.Domain.Dtos;
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
    private async Task<PagedBaseResponse<ReadFilmeDto>> GetFilmesWithAverageRatingsAsync(PagedBaseResponse<Filme> filmes)
    {
        var resultado = _mapper.Map<PagedBaseResponse<ReadFilmeDto>>(filmes);
        foreach (var filme in resultado.Data)
        {
            try
            {
                var avaliacaoMedia = await _filmeRepository.GetAverageRatingsAsync(filme.Id);
                filme.AvaliacaoMedia = avaliacaoMedia;
            }
            catch (Exception)
            {
                filme.AvaliacaoMedia = 0;
            }
        }
        return resultado;
    }

    public async Task<ResultService<ReadFilmeDto>> CreateAsync(CreateFilmeDto filmeDto)
    {
        var resultado = new CreateFilmeValidation().Validate(filmeDto);
        if (!resultado.IsValid)
            return ResultService.RequestError<ReadFilmeDto>("Informe um objeto válido", resultado);

        var filmeExiste = await _filmeRepository.CheckMovieExists(filmeDto.Nome);
        if (filmeExiste != null)
            return ResultService.Fail<ReadFilmeDto>("Já existe um filme cadastrado com esse nome", 409);

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

    public async Task<ResultService<ReadFilmeDto>> GetByIdAsync(int id)
    {
        var filme = await _filmeRepository.GetByIdAsync(id);
        if (filme == null)
            return ResultService.Fail<ReadFilmeDto>("Filme não encontrado");
        var media = await _filmeRepository.GetAverageRatingsAsync(id);
        var data = _mapper.Map<ReadFilmeDto>(filme);
        data.AvaliacaoMedia = media;
        return ResultService.Ok(data);
    }

    public async Task<ResultService<ReadFilmeDto>> UpdateAsync(int id, UpdateFilmeDto filmeDto)
    {
        var resultado = new UpdateFilmeValidation().Validate(filmeDto);
        if (!resultado.IsValid)
            return ResultService.RequestError<ReadFilmeDto>("Informe um objeto válido", resultado);

        var filme = await _filmeRepository.GetByIdAsync(id);
        if (filme == null)
            return ResultService.Fail<ReadFilmeDto>("Filme não encontrado");

        filme = _mapper.Map(filmeDto, filme);
        var data = await _filmeRepository.UpdateAsync(filme);
        var readFilmeDto = _mapper.Map<ReadFilmeDto>(data);
        return ResultService.Ok<ReadFilmeDto>(readFilmeDto, 204);
    }

    public async Task<ResultService<PagedBaseResponse<ReadFilmeDto>>> GetPagedAsync(FilmeFilterDto filmeFilterDto)
    {
        PagedBaseResponse<Filme> filmes;

        if (!string.IsNullOrWhiteSpace(filmeFilterDto.Nome))
        {
            filmes = await _filmeRepository.GetByName(filmeFilterDto.Nome, filmeFilterDto.Page, filmeFilterDto.PageSize);
        }
        else if (!string.IsNullOrWhiteSpace(filmeFilterDto.Genero))
        {
            filmes = await _filmeRepository.GetByGender(filmeFilterDto.Genero, filmeFilterDto.Page, filmeFilterDto.PageSize);

        }
        else if (!string.IsNullOrWhiteSpace(filmeFilterDto.Diretor))
        {
            filmes = await _filmeRepository.GetByDirector(filmeFilterDto.Diretor, filmeFilterDto.Page, filmeFilterDto.PageSize);
        } 
        else
        {
            filmes = await _filmeRepository.GetAllAsync(filmeFilterDto.Page, filmeFilterDto.PageSize);
        }

        var data = await GetFilmesWithAverageRatingsAsync(filmes);
        return ResultService.Ok(data);
    }
}
