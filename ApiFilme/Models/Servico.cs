using System.ComponentModel.DataAnnotations;

namespace ApiFilme.Models
{
    public class Servico
    {
        [Key]
        [Required]
        public int ServicoId { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O TempoDeExecucao é obrigatório")]
        public TimeSpan TempoDeExecucao { get; set; }
        [Required(ErrorMessage = "O Valor é obrigatório")]
        public decimal Valor { get; set; }
        public virtual ICollection<Agenda> Agendas { get; set; }    
        
        public Servico(int horas, int minutos)// Construtor que permite definir horas e minutos
        {
            TempoDeExecucao = new TimeSpan(horas, minutos, 0);
        }
        public Servico(TimeSpan tempoDeExecucao)// Construtor que permite definir diretamente o TimeSpan
        {
            TempoDeExecucao = tempoDeExecucao;
        }

       
        public void Executar() // Método para executar o serviço
        {
            // Exemplo de lógica do serviço
            Console.WriteLine($"O serviço irá executar por {TempoDeExecucao.TotalMinutes} minutos.");

            // Simulando o tempo de execução com Thread.Sleep (não recomendado em produção)
            System.Threading.Thread.Sleep(TempoDeExecucao);
        }
    }

    #region Exemplo de uso
    //class Program
    //{
    //    static void Main()
    //    {
    //        // Criando um serviço com 2 horas e 30 minutos de duração
    //        Servico servico = new Servico(2, 30);

    //        // Executando o serviço
    //        servico.Executar();

    //        // Outra forma de criar um serviço com TimeSpan diretamente
    //        Servico outroServico = new Servico(new TimeSpan(1, 45, 0));

    //        // Executando o outro serviço
    //        outroServico.Executar();
    //    }

    //}
    #endregion
}
