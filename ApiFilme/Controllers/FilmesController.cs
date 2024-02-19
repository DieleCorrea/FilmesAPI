using ApiFilme.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 0;

        [HttpPost]//responsavel por inserir os recursos no sistema 
        public void AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
            Console.WriteLine(filme.Duracao);

        }

        [HttpGet]//responsavel por ler os recursos do sistema
        public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip=0,
            [FromQuery] int take=50)
        {
            return filmes.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]//responsavel por ler os recursos do sistema
        public Filme? RecuperaFilmesPorId(int id)
        {
            return filmes.FirstOrDefault(filme => filme.Id ==  id);
        }
    }
}
