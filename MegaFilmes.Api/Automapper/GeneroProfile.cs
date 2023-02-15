using AutoMapper;
using MegaFilmes.Domain.Dtos.GeneroDto;
using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Api.Automapper;

public class GeneroProfile : Profile
{
	public GeneroProfile()
	{
		CreateMap<CreateGeneroDto, Genero>();
		CreateMap<Genero, ReadGeneroDto>();
    }
}
