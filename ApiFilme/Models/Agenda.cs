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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan HoraInicio { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan HoraConclusao { get; set; }

        public string? Anotacoes { get; set; }

    }
}
//-**Campos * *:
//  - `AgendaId` (chave primária)
//  - `ClienteId` (chave estrangeira referenciando `Clientes`)
//  - `ServicoId` (chave estrangeira referenciando `Servicos`)
//  - `Data`
//  - `Anotacoes`
