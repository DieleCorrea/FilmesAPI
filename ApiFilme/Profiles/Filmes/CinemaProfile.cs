using ApiFilme.Data.Dtos.Filmes;
using ApiFilme.Models.Flmes;
using AutoMapper;

namespace ApiFilme.Profiles.Filmes
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(cinemaDto => cinemaDto.Endereco, opt => opt.MapFrom(Cinema => Cinema.Endereco))//para o membro de ReadEnderecoDto eu mapeio de Endereco
            .ForMember(cinemaDto => cinemaDto.Sessoes, opt => opt.MapFrom(Cinema => Cinema.Sessoes));//para o membro de ReadEnderecoDto eu mapeio de Endereco
            CreateMap<UpdateCinemaDto, Cinema>();

        }
    }
}
