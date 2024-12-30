using System.Linq;
using System.Web.Mvc;
using SistemaReservas.Models;
using Dapper;
using System.Data.SqlClient;

namespace SistemaReservas.Controllers
{
    public class ReservasController : Controller
    {
        private readonly string _connectionString = "Server=DESKTOP-CD60BN4;Database=SistemaReservas;User Id=corparques;Password=12345;";

        public ActionResult Index()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var reservas = connection.Query<Reserva>(
                    "SELECT r.Id, r.Usuario, r.FechaReserva, s.Nombre AS SalaNombre " +
                    "FROM Reservas r INNER JOIN Salas s ON r.SalaId = s.Id").ToList();
                return View(reservas);
            }
        }

        public ActionResult Create()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                ViewBag.Salas = connection.Query<Sala>("SELECT * FROM Salas WHERE Activa = 1").ToList();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Reserva reserva)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var disponible = connection.QueryFirstOrDefault<bool>(
                    "EXEC ValidarDisponibilidad @SalaId, @FechaReserva",
                    new { reserva.SalaId, reserva.FechaReserva });

                if (!disponible)
                {
                    ModelState.AddModelError("", "La sala no está disponible para la fecha seleccionada.");
                    ViewBag.Salas = connection.Query<Sala>("SELECT * FROM Salas WHERE Activa = 1").ToList();
                    return View(reserva);
                }

                connection.Execute("INSERT INTO Reservas (SalaId, FechaReserva, Usuario) VALUES (@SalaId, @FechaReserva, @Usuario)", reserva);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("DELETE FROM Reservas WHERE Id = @Id", new { Id = id });
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var reserva = connection.QueryFirstOrDefault<Reserva>(
                    "SELECT * FROM Reservas WHERE Id = @Id", new { Id = id });
                ViewBag.Salas = connection.Query<Sala>("SELECT * FROM Salas WHERE Activa = 1").ToList();
                return View(reserva);
            }
        }

        [HttpPost]
        public ActionResult Edit(Reserva reserva)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var disponible = connection.QueryFirstOrDefault<bool>(
                    "EXEC ValidarDisponibilidad @SalaId, @FechaReserva",
                    new { reserva.SalaId, reserva.FechaReserva });

                if (!disponible)
                {
                    ModelState.AddModelError("", "La sala no está disponible para la fecha seleccionada.");
                    ViewBag.Salas = connection.Query<Sala>("SELECT * FROM Salas WHERE Activa = 1").ToList();
                    return View(reserva);
                }

                connection.Execute(
                    "UPDATE Reservas SET SalaId = @SalaId, FechaReserva = @FechaReserva, Usuario = @Usuario WHERE Id = @Id",
                    reserva);
            }
            return RedirectToAction("Index");
        }
    }
}