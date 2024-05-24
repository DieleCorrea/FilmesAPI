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
            CreateMap<Agenda, ReadAgendaDto>()
                .ForMember(agendadto => agendadto.Cliente, opt => opt.MapFrom(Agenda => Agenda.Cliente))
                .ForMember(agendadto => agendadto.Servico, opt => opt.MapFrom(Agenda => Agenda.Servico));
        }
    }
}
