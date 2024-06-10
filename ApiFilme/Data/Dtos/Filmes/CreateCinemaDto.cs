using System.ComponentModel.DataAnnotations;

namespace ApiFilme.Data.Dtos.Filmes
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O camppo nome é obrigatório")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }


    }
}
