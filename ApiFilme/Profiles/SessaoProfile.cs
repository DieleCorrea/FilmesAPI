using ApiFilme.Data.Dtos;
using ApiFilme.Models;
using AutoMapper;

namespace ApiFilme.Profiles
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
