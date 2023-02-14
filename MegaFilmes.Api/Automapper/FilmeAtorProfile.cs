using AutoMapper;
using MegaFilmes.Domain.Dtos.FilmeAtorDto;
using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Api.Automapper;

public class FilmeAtorProfile : Profile
{
    public FilmeAtorProfile() 
    {
        CreateMap<CreateFilmeAtorDto, FilmeAtor>();
        CreateMap<UpdateFilmeAtorDto, FilmeAtor>();
        CreateMap<FilmeAtor, ReadFilmeAtorDto>();
    }
}
