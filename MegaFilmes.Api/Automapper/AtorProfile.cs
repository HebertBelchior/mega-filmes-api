using AutoMapper;
using MegaFilmes.Domain.Dtos.AtorDto;
using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Api.Automapper;

public class AtorProfile : Profile
{
    public AtorProfile() 
    {
        CreateMap<CreateAtorDto, Ator>();
        CreateMap<UpdateAtorDto, Ator>();
        CreateMap<Ator, ReadAtorDto>();
    }
}
