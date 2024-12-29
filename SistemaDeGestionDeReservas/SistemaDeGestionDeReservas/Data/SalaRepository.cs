using Dapper;
using SistemaDeGestionDeReservas.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SistemaDeGestionDeReservas.Data
{
    public class SalaRepository
    {
        private readonly IDbConnection _dbConnection;

        public SalaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Sala GetById(int id)
        {
            return _dbConnection.QuerySingleOrDefault<Sala>(
                "SELECT * FROM Salas WHERE Id = @Id", new { Id = id });
        }

        public void Add(Sala sala)
        {
            _dbConnection.Execute(
                "INSERT INTO Salas (Nombre, Capacidad, Disponibilidad) VALUES (@Nombre, @Capacidad, @Disponibilidad)",
                sala);
        }

        public void Delete(int id)
        {
            _dbConnection.Execute("DELETE FROM Salas WHERE Id = @Id", new { Id = id });
        }
        public void Update(Sala sala)
        {
            _dbConnection.Execute(
                "UPDATE Salas SET Nombre = @Nombre, Capacidad = @Capacidad, Disponibilidad = @Disponibilidad WHERE Id = @Id",
                sala);
        }

        public List<Sala> GetAll()
        {
            return _dbConnection.Query<Sala>("SELECT * FROM Salas").ToList();
        }
    }
}