using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaReservas.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public string Ubicacion { get; set; }
        public bool Activa { get; set; }
    }
}