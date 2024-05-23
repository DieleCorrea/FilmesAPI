using ApiFilme.Data.Dtos;
using ApiFilme.Models;
using AutoMapper;

namespace ApiFilme.Profiles
{
    public class AgendaProfile : Profile
    {
        public AgendaProfile()
        {
            CreateMap<CreateAgendaDto, Agenda>();
            CreateMap<UpdateAgendaDto, Agenda>();
            CreateMap<Agenda, ReadAgendaDto>();
        }
    }
}
