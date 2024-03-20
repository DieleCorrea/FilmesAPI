using System.ComponentModel.DataAnnotations;

namespace ApiFilme.Models
{
    public class Filme
    {
        [Key]
        [Required] 
        public int Id { get; set; }

        [Required(ErrorMessage = "O titulo é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O Genero é obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho do genero não pode passar o máximo de 50 caracteres")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "A duração é obrigatória")]
        [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 e 600 minutos")]
        public int Duracao { get; set; }
        public virtual ICollection<Sessao>  Sessoes { get; set; } //um filme pode ter uma ou muitas sessoes 

    }
}
