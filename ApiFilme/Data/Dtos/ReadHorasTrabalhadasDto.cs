namespace ApiFilme.Data.Dtos
{
    public class ReadHorasTrabalhadasDto
    {
        public int Id { get; set; }
        //public string? Manha { get; set; }
        //public string? Tarde { get; set; }
        //public string? Noite { get; set; }
        public TimeOnly? ManhaTurnoInicio { get; set; }
        public TimeOnly? ManhaTurnoFim { get; set; }
        public TimeOnly? TardeTurnoInicio { get; set; }
        public TimeOnly? TardeTurnoFim { get; set; }
        public TimeOnly? NoiteTurnoInicio { get; set; }
        public TimeOnly? NoiteTurnoFim { get; set; }
    }
}
