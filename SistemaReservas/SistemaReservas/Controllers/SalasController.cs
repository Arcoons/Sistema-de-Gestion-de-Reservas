using System.Linq;
using System.Web.Mvc;
using SistemaReservas.Models;
using Dapper;
using System.Data.SqlClient;

namespace SistemaReservas.Controllers
{
    public class SalasController : Controller
    {
        private readonly string _connectionString = "Server=DESKTOP-CD60BN4;Database=SistemaReservas;User Id=corparques;Password=12345;";

        public ActionResult Index()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var salas = connection.Query<Sala>("SELECT * FROM Salas").ToList();
                return View(salas);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateAjax(Sala sala)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("INSERT INTO Salas (Nombre, Capacidad, Ubicacion, Activa) VALUES (@Nombre, @Capacidad, @Ubicacion, @Activa)", sala);
            }
            return Json(new { success = true });
        }

        public ActionResult Edit(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sala = connection.QueryFirstOrDefault<Sala>("SELECT * FROM Salas WHERE Id = @Id", new { Id = id });
                return View(sala);
            }
        }

        [HttpPost]
        public ActionResult Edit(Sala sala)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("UPDATE Salas SET Nombre = @Nombre, Capacidad = @Capacidad, Ubicacion = @Ubicacion, Activa = @Activa WHERE Id = @Id", sala);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult DeleteAjax(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("DELETE FROM Salas WHERE Id = @Id", new { Id = id });
            }
            return Json(new { success = true });
        }
    }
}