using AutoMapper;
using MegaFilmes.Domain.Dtos.AvaliacaoDto;
using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Api.Automapper;

public class AvaliacaoProfile : Profile
{
	public AvaliacaoProfile()
	{
		CreateMap<CreateAvaliacaoDto, Avaliacao>();
		CreateMap<Avaliacao, ReadAvaliacaoDto>();
	}
}
