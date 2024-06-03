using ApiFilme.Data;
using ApiFilme.Data.Dtos;
using ApiFilme.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public ClienteController(FilmeContext filmeContext, IMapper mapper)
        {
            _context = filmeContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCliente([FromBody] CreateClienteDto createCliente )
        {
            Cliente cliente = _mapper.Map<Cliente>(createCliente);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaClientePorId), new { Id = cliente.ClienteId }, createCliente);
        }
        [HttpGet]
        public IEnumerable<ReadClienteDto> RecuperaCliente()
        {
            return _mapper.Map<List<ReadClienteDto>>(_context.Clientes.ToList());

        }
        [HttpGet("{id}")]
        public IActionResult RecuperaClientePorId(int id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.ClienteId == id);
            if (cliente != null)
            {
                ReadClienteDto clienteDto = _mapper.Map<ReadClienteDto>(cliente);
                return Ok(clienteDto);
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AtualizaCliente(int id, [FromBody] UpdateClienteDto clienteDto)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _mapper.Map(clienteDto, cliente);
            _context.SaveChanges();
            ReadClienteDto read = _mapper.Map<ReadClienteDto>(cliente);
            return Ok(read);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaCliente(int id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
