using ApiFilme.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        public static List<Filme> filmes = new List<Filme>();

        [HttpPost]//responsavel por inserir os recursos no sistema 
        public void AdicionaFilme([FromBody] Filme filme)
        {
            filmes.Equals(filme);
            Console.WriteLine(filme.Titulo);
            Console.WriteLine(filme.Duracao);

        }

        [HttpGet]//responsavel por ler os recursos do sistema
        public List<Filme> recuperaFilmes()
        {
            return filmes;
        }

    }
}
