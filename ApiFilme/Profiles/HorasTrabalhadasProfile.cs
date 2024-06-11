using ApiFilme.Data.Dtos;
using ApiFilme.Models;
using AutoMapper;

namespace ApiFilme.Profiles
{
    public class HorasTrabalhadasProfile : Profile
    {
        public HorasTrabalhadasProfile()
        {
            CreateMap<CreateHorasTrabalhadasDto, HorasTrabalhadas>();
            CreateMap<HorasTrabalhadas, ReadHorasTrabalhadasDto>();
            CreateMap<UpdateHorasTrabDto, HorasTrabalhadas>();
        }
       
    }
}
