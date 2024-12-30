using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaReservas.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public string SalaNombre { get; set; }
        public string Usuario { get; set; }
        public System.DateTime FechaReserva { get; set; }
    }
}