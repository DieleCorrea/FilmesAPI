using ApiFilme.Data;
using ApiFilme.Data.Dtos;
using ApiFilme.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendaController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public AgendaController(FilmeContext filmeContext, IMapper mapper)
        {
            _context = filmeContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaAgenda([FromBody] CreateAgendaDto createAgenda)
        {
            Agenda agenda = _mapper.Map<Agenda>(createAgenda);
            _context.Agendas.Add(agenda);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaAgendaPorId), new { id = agenda.AgendaId }, agenda);
        }
        [HttpGet]
        public IEnumerable<ReadAgendaDto> RecuperaAgenda()
        {
            return _mapper.Map<List<ReadAgendaDto>>(_context.Agendas.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaAgendaPorId(int id)
        {
            Agenda agenda = _context.Agendas.FirstOrDefault(agenda => agenda.AgendaId == id);
            if(agenda != null)
            {
                ReadAgendaDto readAgenda = _mapper.Map<ReadAgendaDto>(agenda);
                return Ok(readAgenda);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AtualizaAgenda(int id, [FromBody] UpdateAgendaDto AgendaDto)
        {
            Agenda agenda = _context.Agendas.FirstOrDefault(agenda => agenda.AgendaId == id);
            if (agenda == null)
            {
                return NotFound();
            }
            _mapper.Map(AgendaDto, agenda);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAgenda(int id)
        {
            Agenda agenda = _context.Agendas.FirstOrDefault(agenda=>agenda.AgendaId == id);
            if(agenda == null)
            {
                return NotFound();
            }
            _context.Remove(agenda);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
