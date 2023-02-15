using AutoMapper;
using MegaFilmes.Api.Services.Interfaces;
using MegaFilmes.Domain.Dtos.FilmeAtorDto;
using MegaFilmes.Domain.Entities;
using MegaFilmes.Domain.Interfaces.Repository;
using MegaFilmes.Domain.Validations;

namespace MegaFilmes.Api.Services;

public class FilmeAtorService : IFilmeAtorService
{
    private readonly IFilmeAtorRepository _repository;
    private readonly IAtorRepository _atorRepository;
    private readonly IFilmeRepository _filmeRepository;
    private readonly IMapper _mapper;

    public FilmeAtorService(IFilmeAtorRepository repository, IAtorRepository atorRepository, IFilmeRepository filmeRepository, IMapper mapper)
    {
        _repository = repository;
        _atorRepository = atorRepository;
        _filmeRepository = filmeRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<ReadFilmeAtorDto>> CreateAsync(CreateFilmeAtorDto filmeAtorDto)
    {
        var resultado = new CreateFilmeAtorValidation().Validate(filmeAtorDto);
        if (!resultado.IsValid)
            return ResultService.RequestError<ReadFilmeAtorDto>("Informe um objeto válido", resultado);
        var errorMessage = string.Empty;
        if (CheckIfExists(filmeAtorDto.AtorId, filmeAtorDto.FilmeId, ref errorMessage))
        {
            var filmeAtor = _mapper.Map<FilmeAtor>(filmeAtorDto);
            var data = await _repository.CreateAsync(filmeAtor);
            return ResultService.Ok(_mapper.Map<ReadFilmeAtorDto>(data), 201);
        }
        return ResultService.Fail<ReadFilmeAtorDto>(errorMessage, 409);
    }


    public async Task<ResultService> DeleteAsync(int id)
    {
        var filmeAtor = await _repository.GetByIdAsync(id);
        if (filmeAtor == null)
            return ResultService.Fail("Ator não encontrado nesse filme", 404);

        await _repository.DeleteAsync(filmeAtor);
        return ResultService.Ok("Ator removido com sucesso desse filme", 204);
    }

    public async Task<ResultService<ICollection<ReadFilmeAtorDto>>> GetAllAsync()
    {
        var filmeAtor = await _repository.GetAllAsync();
        var data = _mapper.Map<ICollection<ReadFilmeAtorDto>>(filmeAtor);
        return ResultService.Ok(data);
    }

    public async Task<ResultService<ICollection<ReadFilmeAtorDto>>> GetByAtorId(int id)
    {
        var filmeAtor = await _repository.GetByAtorId(id);
        var data = _mapper.Map<ICollection<ReadFilmeAtorDto>>(filmeAtor);
        if (data.Count == 0)
        {
            return ResultService.Fail<ICollection<ReadFilmeAtorDto>>("Nenhum registro encontrado para o ator informado", 404);
        }
        return ResultService.Ok(data);
    }

    public async Task<ResultService<ICollection<ReadFilmeAtorDto>>> GetByFilmeId(int id)
    {
        var filmeAtor = await _repository.GetByFilmeId(id);
        var data = _mapper.Map<ICollection<ReadFilmeAtorDto>>(filmeAtor);
        if (data.Count == 0)
        {
            return ResultService.Fail<ICollection<ReadFilmeAtorDto>>("Nenhum registro encontrado para o filme informado", 404);
        }
        return ResultService.Ok(data);
    }

    public async Task<ResultService<ReadFilmeAtorDto>> GetByIdAsync(int id)
    {
        var filmeAtor = await _repository.GetByIdAsync(id);
        if (filmeAtor == null)
            return ResultService.Fail<ReadFilmeAtorDto>("Ator não encontrado nesse filme");
        var data = _mapper.Map<ReadFilmeAtorDto>(filmeAtor);
        return ResultService.Ok(data);
    }

    public async Task<ResultService<ICollection<ReadFilmeAtorDto>>> GetByPapel(string papel)
    {
        var filmeAtor = await _repository.GetByPapel(papel);
        var data = _mapper.Map<ICollection<ReadFilmeAtorDto>>(filmeAtor);
        if (data.Count == 0)
        {
            return ResultService.Fail<ICollection<ReadFilmeAtorDto>>("Nenhum registro encontrado para o papel informado", 404);
        }
        return ResultService.Ok(data);
    }

    public async Task<ResultService<ReadFilmeAtorDto>> UpdateAsync(int id, UpdateFilmeAtorDto filmeAtorDto)
    {
        var resultado = new UpdateFilmeAtorValidation().Validate(filmeAtorDto);
        if (!resultado.IsValid)
            return ResultService.RequestError<ReadFilmeAtorDto>("Informe um objeto válido", resultado);

        var filmeAtor = await _repository.GetByIdAsync(id);
        if (filmeAtor == null)
            return ResultService.Fail<ReadFilmeAtorDto>("Ator não encontrado nesse filme");

        var errorMessage = string.Empty;
        if (CheckIfExists(filmeAtorDto.AtorId, filmeAtorDto.FilmeId, ref errorMessage))
        {
            filmeAtor = _mapper.Map(filmeAtorDto, filmeAtor);
            var data = await _repository.UpdateAsync(filmeAtor);
            var readFilmeDto = _mapper.Map<ReadFilmeAtorDto>(data);
            return ResultService.Ok(readFilmeDto, 204);
        }
        return ResultService.Fail<ReadFilmeAtorDto>(errorMessage, 409);
    }

    private bool CheckIfExists(int atorId, int filmeId, ref string? errorMessage)
    {
        var errorMessages = new List<string>();
        var ator = _atorRepository.GetByIdAsync(atorId).Result;
        var filme = _filmeRepository.GetByIdAsync(filmeId).Result;
        var filmeAtor = _repository.CheckExists(atorId, filmeId).Result;

        if (ator == null)
        {
            errorMessages.Add("Ator não existe");
        }

        if (filme == null)
        {
            errorMessages.Add("Filme não existe");
        }

        if (filmeAtor != null)
        {
            errorMessages.Add("Este papel já atribuido a este ator");
        }

        errorMessage = string.Join(", ", errorMessages);
        return string.IsNullOrEmpty(errorMessage);
    }
}
