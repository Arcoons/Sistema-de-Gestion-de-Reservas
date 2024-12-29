using Dapper;
using SistemaDeGestionDeReservas.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SistemaDeGestionDeReservas.Data
{
    public class ReservaRepository
    {
        private readonly IDbConnection _dbConnection;

        public ReservaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Reserva GetById(int id)
        {
            return _dbConnection.QuerySingleOrDefault<Reserva>(
                "SELECT * FROM Reservas WHERE Id = @Id", new { Id = id });
        }

        public void Add(Reserva reserva)
        {
            _dbConnection.Execute(
                "INSERT INTO Reservas (SalaId, Usuario, FechaReserva) VALUES (@SalaId, @Usuario, @FechaReserva)",
                reserva);
        }

        public void Delete(int id)
        {
            _dbConnection.Execute("DELETE FROM Reservas WHERE Id = @Id", new { Id = id });
        }

        public List<Reserva> GetAll()
        {
            return _dbConnection.Query<Reserva>("SELECT * FROM Reservas").ToList();
        }
    }
}