using System.ComponentModel.DataAnnotations;

namespace ApiFilme.Data.Dtos
{
    public class CreateServicoDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O TempoDeExecucao é obrigatório")]
        public TimeOnly TempoDeExecucao { get; set; }
        [Required(ErrorMessage = "O Valor é obrigatório")]
        public decimal Valor { get; set; }
    }
}
