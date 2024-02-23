using ApiFilme.Data;
using ApiFilme.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using static System.Net.WebRequestMethods;

namespace ApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public FilmesController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]//responsavel por inserir os recursos no sistema 
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            //chamar o automapper para ele converter CreateFilmeDto para um filme
            Filme filme = _mapper.Map<Filme>(filmeDto);
           _context.Filmes.Add(filme);
            _context.SaveChanges();//Salva as  alteraações feitas
            //esse return é para informar ao meu usuario no header do postman qual caminho ele pode encontrar esse filme recem criado 
            #region Explicação
            //Resposta do ChatGPT: *A razão pela qual você está utilizando CreatedAtAction para retornar o resultado em vez de simplesmente return filme pode estar relacionada à convenção RESTful de design de APIs.

            //O método CreatedAtAction cria uma resposta HTTP 201(Created) com um cabeçalho Location que indica o URI do novo recurso criado.Isso é uma boa prática para indicar que uma nova entidade foi criada com sucesso e fornece ao cliente o link para acessar esse novo recurso.

            //No seu caso, o CreatedAtAction está sendo usado para indicar que um novo filme foi adicionado e fornece um link para recuperar esse filme pelo seu ID. O cliente pode então fazer uma nova requisição usando esse link para obter os detalhes do filme recém-criado.

            //Se você simplesmente retornasse filme, o cliente receberia os detalhes do filme, mas não teria uma indicação clara de que um novo recurso foi criado, e não teria um link direto para acessar esse recurso no futuro.

            //Portanto, a escolha de usar CreatedAtAction é uma boa prática para fornecer uma resposta mais informativa e conforme às convenções RESTful.*
            #endregion
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { id = filme.Id }, filme);
     
        }

        [HttpGet]//responsavel por ler os recursos do sistema
        public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip=0,
            [FromQuery] int take=50)
        {
            return _context.Filmes.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id ==  id);
            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }
    }
}
