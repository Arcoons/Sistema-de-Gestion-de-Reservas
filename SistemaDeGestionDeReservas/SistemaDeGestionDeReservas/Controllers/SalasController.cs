using Microsoft.AspNetCore.Mvc;
using SistemaDeGestionDeReservas.Data;
using SistemaDeGestionDeReservas.Models;

namespace SistemaDeGestionDeReservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalasController : ControllerBase
    {
        private readonly SalaRepository _repository;

        public SalasController(SalaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_repository.GetById(id));

        [HttpPost]
        public IActionResult Create(Sala sala)
        {
            _repository.Add(sala);
            return CreatedAtAction(nameof(GetById), new { id = sala.Id }, sala);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Sala sala)
        {
            if (id != sala.Id) return BadRequest();
            _repository.Update(sala);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}