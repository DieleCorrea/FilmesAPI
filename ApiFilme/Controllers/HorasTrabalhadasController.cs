using ApiFilme.Data;
using ApiFilme.Data.Dtos;
using ApiFilme.Models;
using ApiFilme.Models.Flmes;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HorasTrabalhadasController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public HorasTrabalhadasController(FilmeContext filmeContext, IMapper mapper)
        {
            _context = filmeContext;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AdicionaHoras([FromBody] CreateHorasTrabalhadasDto createHoras)
        {
            HorasTrabalhadas horas = _mapper.Map<HorasTrabalhadas>(createHoras);
            _context.HorasTrabalhadas.Add(horas);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet("{id}")]
        public IActionResult ObterHoras(int id)
        {
            HorasTrabalhadas horas = _context.HorasTrabalhadas.FirstOrDefault(horas => horas.Id == id);
            if (horas != null)
            {
                ReadHorasTrabalhadasDto horasDto = _mapper.Map<ReadHorasTrabalhadasDto>(horas);
                return Ok(horasDto);    
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AtualizaHoras(int id, [FromBody] UpdateHorasTrabDto horasTrabDto  )
        {
            HorasTrabalhadas horas = _context.HorasTrabalhadas.FirstOrDefault(horas => horas.Id == id);
            if (horas == null)
            {
                return NotFound();
            }
            _mapper.Map(horasTrabDto, horas);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
