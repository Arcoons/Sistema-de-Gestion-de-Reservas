namespace SistemaDeGestionDeReservas.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaReserva { get; set; }
    }
}