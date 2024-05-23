using ApiFilme.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiFilme.Models
{
    public class Agenda
    {
        [Key]
        [Required]
        public int AgendaId { get; set; }
        [Required]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required]
        public int ServicoId { get; set; }
        public virtual Servico Servico { get; set; }
        [Required]
        public DateTime Data { get; set; }
        public string? Anotacoes { get; set; }

    }
}
//-**Campos * *:
//  - `AgendaId` (chave primária)
//  - `ClienteId` (chave estrangeira referenciando `Clientes`)
//  - `ServicoId` (chave estrangeira referenciando `Servicos`)
//  - `Data`
//  - `Anotacoes`
