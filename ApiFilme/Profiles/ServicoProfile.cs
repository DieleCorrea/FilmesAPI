using ApiFilme.Data.Dtos;
using ApiFilme.Models;
using AutoMapper;

namespace ApiFilme.Profiles
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            CreateMap<CreateServicoDto, Servico>();
            CreateMap<Servico, ReadServicoDto>();
            CreateMap<UpdateServicoDto, Servico>();
        }
    }
}
