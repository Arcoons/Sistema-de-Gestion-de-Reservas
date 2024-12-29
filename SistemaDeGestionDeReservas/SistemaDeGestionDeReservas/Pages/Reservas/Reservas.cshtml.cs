using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaDeGestionDeReservas.Data;
using SistemaDeGestionDeReservas.Models;
using System.Collections.Generic;

namespace SistemaDeGestionDeReservas.Pages.Reservas
{
    public class ReservasModel : PageModel
    {
        private readonly ReservaRepository _repository;

        public ReservasModel(ReservaRepository repository)
        {
            _repository = repository;
        }

        public List<Reserva> Reservas { get; set; } // Define la propiedad

        public void OnGet()
        {
            Reservas = _repository.GetAll(); // Carga las reservas desde el repositorio
        }
    }
}
