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
        public DateTime Data { get; set; }
        public string? Anotacoes { get; set; }
    }
}
