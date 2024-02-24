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
        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody]UpdateFilmeDto filmeDto )
        {
            //recupera o filme do banco apartir do id que tem la, e ve se é nullo, caso for  nulo retorna um notfound
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                NotFound();
            }
            //Deu tudo certo e não é null, então vai mapear filmeDto para filme e salvar as mudanças 
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            //Tendo salvado, retornamos  um statusCode que é o NoConotent() retornamos ele normalmente quando fazemos  uma ALTERAÇÃO 
            return NoContent();
            #region Porque retorna NoContent()
                /*
                    -Indica sucesso: 
                        O status HTTP 204 indica que a solicitação foi processada com sucesso pelo servidor, mas não há conteúdo a ser retornado no corpo da resposta. 
                        Isso é útil em casos onde a alteração feita não requer uma resposta com dados específicos. Por exemplo, ao deletar um recurso, não há necessidade de retornar 
                        os detalhes desse recurso após a exclusão
                    -Reduz a sobrecarga de dados: 
                        Retornar um corpo vazio com um status 204 economiza largura de banda e reduz o tempo de processamento, 
                        pois não há necessidade de enviar dados desnecessários pela rede.
                    -Sem informações adicionais: 
                        Se o cliente já possui todas as informações necessárias para entender o resultado da solicitação (por exemplo, ao atualizar um recurso),
                        não há necessidade de retornar informações adicionais
                    -Padrão em muitos frameworks e bibliotecas:
                        Muitos frameworks e bibliotecas para desenvolvimento de APIs e serviços da web implementam a lógica de retornar 
                        um status 204 em certas circunstâncias (como ao deletar um recurso) como parte das convenções e boas práticas de desenvolvimento

                Portanto, retornar um status 204 No Content é uma maneira eficiente e padronizada de indicar que uma operação foi realizada com sucesso, 
                mas não há dados específicos para retornar como parte da resposta.
                */
            #endregion
        }
    }
}
