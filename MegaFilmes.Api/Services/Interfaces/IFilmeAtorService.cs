using MegaFilmes.Domain.Dtos.FilmeAtorDto;

namespace MegaFilmes.Api.Services.Interfaces;

public interface IFilmeAtorService
{
    Task<ResultService<ICollection<ReadFilmeAtorDto>>> GetAllAsync();
    Task<ResultService<ReadFilmeAtorDto>> GetByIdAsync(int id);
    Task<ResultService<ReadFilmeAtorDto>> CreateAsync(CreateFilmeAtorDto filmeAtorDto);
    Task<ResultService<ReadFilmeAtorDto>> UpdateAsync(int id, UpdateFilmeAtorDto filmeAtorDto);
    Task<ResultService> DeleteAsync(int id);
    Task<ResultService<ICollection<ReadFilmeAtorDto>>> GetByFilmeId(int id);
    Task<ResultService<ICollection<ReadFilmeAtorDto>>> GetByAtorId(int id);
    Task<ResultService<ICollection<ReadFilmeAtorDto>>> GetByPapel(string papel);
}
