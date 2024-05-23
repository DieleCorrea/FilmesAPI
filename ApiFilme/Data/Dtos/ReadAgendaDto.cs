using ApiFilme.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiFilme.Data.Dtos
{
    public class ReadAgendaDto
    {
        public int AgendaId { get; set; }
        public int ClienteId { get; set; }
        public int ServicoId { get; set; }
        public DateTime Data { get; set; }
        public string? Anotacoes { get; set; }
    }
}
