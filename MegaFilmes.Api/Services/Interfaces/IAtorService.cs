using MegaFilmes.Domain.Dtos.AtorDto;

namespace MegaFilmes.Api.Services.Interfaces
{
    public interface IAtorService
    {
        Task<ResultService<ICollection<ReadAtorDto>>> GetAllAsync();
        Task<ResultService<ReadAtorDto>> GetByIdAsync(int id);
        Task<ResultService<ReadAtorDto>> CreateAsync(CreateAtorDto atorDto);
        Task<ResultService<ReadAtorDto>> UpdateAsync(int id, UpdateAtorDto atorDto);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<ICollection<ReadAtorDto>>> GetByName(string nome);
    }
}
