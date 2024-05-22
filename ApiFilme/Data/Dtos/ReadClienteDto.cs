
namespace ApiFilme.Data.Dtos
{
    public class ReadClienteDto
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Contato { get; set; }
        public string? Anotacoes { get; set; }
    }
}
