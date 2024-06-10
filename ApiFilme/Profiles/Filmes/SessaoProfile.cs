using ApiFilme.Data.Dtos.Filmes;
using ApiFilme.Models.Flmes;
using AutoMapper;

namespace ApiFilme.Profiles.Filmes
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>();
        }
    }
}
