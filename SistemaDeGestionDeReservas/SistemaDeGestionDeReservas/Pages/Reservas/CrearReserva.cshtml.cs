using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaDeGestionDeReservas.Data;
using SistemaDeGestionDeReservas.Models;

namespace SistemaDeGestionDeReservas.Pages.Salas
{
    public class CrearEditarSalaModel : PageModel
    {
        private readonly SalaRepository _repository;

        [BindProperty]
        public Sala Sala { get; set; } // Esta propiedad debe estar definida

        public CrearEditarSalaModel(SalaRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Sala = _repository.GetById(id.Value);
                if (Sala == null)
                {
                    return NotFound();
                }
            }
            else
            {
                Sala = new Sala(); // Inicializa la sala para creación
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Sala.Id == 0)
            {
                _repository.Add(Sala);
            }
            else
            {
                _repository.Update(Sala);
            }

            return RedirectToPage("./Salas");
        }
    }
}