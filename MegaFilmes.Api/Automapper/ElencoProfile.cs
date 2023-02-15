using AutoMapper;
using MegaFilmes.Domain.Dtos.FilmeDto;
using MegaFilmes.Domain.Entities;

namespace MegaFilmes.Api.Automapper
{
    public class ElencoProfile : Profile
    {
        public ElencoProfile()
        {
            CreateMap<FilmeAtor, ElencoDto>()
            .ForMember(dest => dest.Ator, opt => opt.MapFrom(src => src.Ator.Nome))
            .ForMember(dest => dest.Papel, opt => opt.MapFrom(src => src.Papel));
        }
    }
}
