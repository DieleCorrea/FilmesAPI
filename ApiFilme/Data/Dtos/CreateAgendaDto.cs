using ApiFilme.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiFilme.Data.Dtos
{
    public class CreateAgendaDto
    {
      
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int ServicoId { get; set; }
        [Required]
        public DateOnly Data { get; set; }

        [Required]
        public TimeOnly HoraInicio { get; set; }

        [Required]
        public TimeOnly HoraConclusao { get; set; }

        public string? Anotacoes { get; set; }
    }
}
