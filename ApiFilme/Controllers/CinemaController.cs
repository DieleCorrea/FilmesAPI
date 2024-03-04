using ApiFilme.Data;
using ApiFilme.Data.Dtos;
using ApiFilme.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiFilme.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CinemaController : ControllerBase
    {
        //injeção da dependencias 
        private FilmeContext _context;
        private IMapper _mapper;
        //contrutor
        public CinemaController(FilmeContext filmeContext, IMapper mapper)
        {
            _context = filmeContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody]CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = cinema.Id}, cinemaDto);
        }

        [HttpGet]
        public IEnumerable<ReadCinemaDto> RecuperaCinemas()
        {
            // Retorna uma lista de objetos do tipo ReadCinemaDto
            // Mapeia os objetos de domínio de cinema para objetos DTO ReadCinemaDto
            // _context.Cinemas.ToList() recupera todos os cinemas do banco de dados e os converte em uma lista
            // _mapper.Map<List<ReadCinemaDto>>(...) faz o mapeamento entre os tipos de objetos
            return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok(cinemaDto);       
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
           Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if( cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
