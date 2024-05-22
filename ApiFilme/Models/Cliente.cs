using System.ComponentModel.DataAnnotations;

namespace ApiFilme.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Contato é obrigatorio")]
        public string Contato { get; set; }
        public string? Anotacoes { get; set; }

        //public virtual ICollection<Agendas> Agendas { get; set; }
    }
}
