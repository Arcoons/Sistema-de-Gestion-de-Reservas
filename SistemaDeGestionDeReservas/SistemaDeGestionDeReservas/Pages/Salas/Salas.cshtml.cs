using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaDeGestionDeReservas.Data;
using SistemaDeGestionDeReservas.Models;
using System.Collections.Generic;

namespace SistemaDeGestionDeReservas.Pages.Salas
{
    public class SalasModel : PageModel
    {
        private readonly SalaRepository _repository;

        public SalasModel(SalaRepository repository)
        {
            _repository = repository;
        }

        public List<Sala> Salas { get; set; } // Define la propiedad

        public void OnGet()
        {
            Salas = _repository.GetAll(); // Carga las salas desde el repositorio
        }
    }
}
