using ApiFilme.Shared.Converts;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiFilme.Data.Dtos
{
    public class CreateServicoDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O TempoDeExecucao é obrigatório")]
        public TimeOnly TempoDeExecucao { get; set; }
        [Required(ErrorMessage = "O Valor é obrigatório")]
        [JsonConverter(typeof(DecimalJsonConverter))]
        public decimal Valor { get; set; }
    }
}
