using System.ComponentModel.DataAnnotations;

namespace ApiFilme.Data.Dtos
{
    public class UpdateClienteDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Contato é obrigatorio")]
        public string Contato { get; set; }
        public string? Anotacoes { get; set; } = null;
    }
}
