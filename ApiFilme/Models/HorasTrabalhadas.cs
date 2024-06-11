using System.ComponentModel.DataAnnotations;

namespace ApiFilme.Models
{
    public class HorasTrabalhadas
    {
        [Key]
        [Required]
        public int Id { get; set; }
        //public string? Manha { get; set; }        
        //public string? Tarde { get; set; }        
        //public string? Noite { get; set; }

        // Propriedades para o Turno Matutino
        public TimeOnly? ManhaTurnoInicio { get; set; }
        public TimeOnly? ManhaTurnoFim { get; set; }

        // Propriedades para o Turno Vespertino
        public TimeOnly? TardeTurnoInicio { get; set; }
        public TimeOnly? TardeTurnoFim { get; set; }

        // Propriedades para o Turno Noturno
        public TimeOnly? NoiteTurnoInicio { get; set; }
        public TimeOnly? NoiteTurnoFim { get; set; }

        // Duração total em horas
        //public int DurationHours { get; set; }
    }
}
