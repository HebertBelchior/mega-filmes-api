using AutoMapper;
using MegaFilmes.Domain.Dtos.FilmeDto;
using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Api.Automapper;

public class FilmeProfile : Profile
{
	public FilmeProfile()
	{
		CreateMap<CreateFilmeDto, Filme>();
		CreateMap<UpdateFilmeDto, Filme>();
		CreateMap<Filme, ReadFilmeDto>();
    }
}
