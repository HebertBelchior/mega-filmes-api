using AutoMapper;
using MegaFilmes.Api.Services.Interfaces;
using MegaFilmes.Domain.Dtos.AtorDto;
using MegaFilmes.Domain.Entities;
using MegaFilmes.Domain.Interfaces.Repository;
using MegaFilmes.Domain.Validations;

namespace MegaFilmes.Api.Services;

public class AtorService : IAtorService
{
    private readonly IAtorRepository _atorRepository;
    private readonly IMapper _mapper;

    public AtorService(IAtorRepository atorRepository, IMapper mapper)
    {
        _atorRepository = atorRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<ReadAtorDto>> CreateAsync(CreateAtorDto atorDto)
    {
        var resultado = new CreateAtorValidation().Validate(atorDto);
        if (!resultado.IsValid)
            return ResultService.RequestError<ReadAtorDto>("Informe um objeto válido", resultado);

        var atorExiste = await _atorRepository.CheckAtorExists(atorDto.Nome);
        if (atorExiste != null)
            return ResultService.Fail<ReadAtorDto>("Já existe um Ator cadastrado com esse nome", 409);

        var ator = _mapper.Map<Ator>(atorDto);
        var data = await _atorRepository.CreateAsync(ator);
        return ResultService.Ok(_mapper.Map<ReadAtorDto>(data), 201);
    }

    public async Task<ResultService> DeleteAsync(int id)
    {
        var ator = await _atorRepository.GetByIdAsync(id);
        if (ator == null)
            return ResultService.Fail("Ator não encontrado");

        await _atorRepository.DeleteAsync(ator);
        return ResultService.Ok("Ator removido com sucesso", 204);
    }

    public async Task<ResultService<ICollection<ReadAtorDto>>> GetAllAsync()
    {
        var ator = await _atorRepository.GetAllAsync();
        var data = _mapper.Map<ICollection<ReadAtorDto>>(ator);
        return ResultService.Ok(data);
    }

    public async Task<ResultService<ReadAtorDto>> GetByIdAsync(int id)
    {
        var ator = await _atorRepository.GetByIdAsync(id);
        if (ator == null)
            return ResultService.Fail<ReadAtorDto>("Ator não encontrado");
        var data = _mapper.Map<ReadAtorDto>(ator);
        return ResultService.Ok(data);
    }

    public async Task<ResultService<ICollection<ReadAtorDto>>> GetByName(string nome)
    {
        var ator = await _atorRepository.GetByName(nome);
        var data = _mapper.Map<ICollection<ReadAtorDto>>(ator);
        return ResultService.Ok(data);
    }

    public async Task<ResultService<ReadAtorDto>> UpdateAsync(int id, UpdateAtorDto atorDto)
    {
        var resultado = new UpdateAtorValidation().Validate(atorDto);
        if (!resultado.IsValid)
            return ResultService.RequestError<ReadAtorDto>("Informe um objeto válido", resultado);

        var ator = await _atorRepository.GetByIdAsync(id);
        if (ator == null)
            return ResultService.Fail<ReadAtorDto>("Ator não encontrado");

        ator = _mapper.Map(atorDto, ator);
        var data = await _atorRepository.UpdateAsync(ator);
        var readAtorDto = _mapper.Map<ReadAtorDto>(data);
        return ResultService.Ok(readAtorDto, 204);
    }
}
