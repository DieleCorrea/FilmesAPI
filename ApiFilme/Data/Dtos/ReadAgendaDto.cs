using ApiFilme.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiFilme.Data.Dtos
{
    public class ReadAgendaDto
    {
        public int AgendaId { get; set; }
        public ReadClienteDto Cliente { get; set; }
        public ReadServicoDto Servico { get; set; }
        public DateTime Data { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraConclusao { get; set; }
        public string? Anotacoes { get; set; }
    }
}
