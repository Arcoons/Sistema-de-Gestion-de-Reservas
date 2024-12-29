using Microsoft.AspNetCore.Mvc;
using SistemaDeGestionDeReservas.Data;
using SistemaDeGestionDeReservas.Models;

namespace SistemaDeGestionDeReservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly ReservaRepository _repository;

        public ReservasController(ReservaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_repository.GetById(id));

        [HttpPost]
        public IActionResult Create(Reserva reserva)
        {
            _repository.Add(reserva);
            return CreatedAtAction(nameof(GetById), new { id = reserva.Id }, reserva);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
