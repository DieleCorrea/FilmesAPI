﻿using System.ComponentModel.DataAnnotations;

namespace ApiFilme.Data.Dtos
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O camppo nome é obrigatório")]
        public string Nome { get; set; }
    }
}
