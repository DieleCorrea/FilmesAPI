using ApiFilme.Data;
using ApiFilme.Data.Dtos;
using ApiFilme.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public ServicoController(FilmeContext filmeContext, IMapper mapper)
        {
            _context = filmeContext;
            _mapper = mapper;   
        }


        [HttpPost]
        public IActionResult AdicionaCliente([FromBody] CreateServicoDto createServico)
        {
            Servico servico = _mapper.Map<Servico>(createServico);
            _context.Servicos.Add(servico);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaServicoPorId), new { Id = servico.ServicoId }, createServico);
        }
        [HttpGet]
        public IEnumerable<ReadServicoDto> RecuperaServico()
        {
            return _mapper.Map<List<ReadServicoDto>>(_context.Servicos.ToList());

        }
        [HttpGet("{id}")]
        public IActionResult RecuperaServicoPorId(int id)
        {
            Servico servico = _context.Servicos.FirstOrDefault(servico => servico.ServicoId == id);
            if (servico != null)
            {
                ReadServicoDto servicoDto = _mapper.Map<ReadServicoDto>(servico);
                return Ok(servicoDto);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AtualizaServico(int id, [FromBody] UpdateServicoDto servicoDto)
        {
            Servico servico = _context.Servicos.FirstOrDefault(servico => servico.ServicoId == id);
            if (servico == null)
            {
                return NotFound();
            }
            _mapper.Map(servicoDto, servico);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaServico(int id)
        {
            Servico servico = _context.Servicos.FirstOrDefault(servico => servico.ServicoId == id);
            if (servico == null)
            {
                return NotFound();
            }
            _context.Remove(servico);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
