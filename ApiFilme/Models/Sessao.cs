using System.ComponentModel.DataAnnotations;

namespace ApiFilme.Models
{
    public class Sessao 
    {
        [Key]
        [Required ]
        public int Id { get; set; }

    }
}
