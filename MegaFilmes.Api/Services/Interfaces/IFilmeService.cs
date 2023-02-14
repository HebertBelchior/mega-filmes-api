using MegaFilmes.Domain.Dtos.FilmeDto;

namespace MegaFilmes.Api.Services.Interfaces;


public interface IFilmeService
{
    Task<ResultService<ReadFilmeDto>> GetByIdAsync(int id);
    Task<ResultService<ReadFilmeDto>> CreateAsync(CreateFilmeDto filmeDto);
    Task<ResultService<ReadFilmeDto>> UpdateAsync(int id, UpdateFilmeDto filmeDto);
    Task<ResultService> DeleteAsync(int id);
    Task<ResultService<ICollection<ReadFilmeDto>>> GetPagedAsync(FilmeFilterDto filmeFilterDto);
}
