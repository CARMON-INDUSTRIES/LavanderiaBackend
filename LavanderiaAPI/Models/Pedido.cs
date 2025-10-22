using System;
using System.Collections.Generic;

namespace LavanderiaAPI.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public DateTime FechaEntrega { get; set; }

        public string Estado { get; set; } = "Pendiente";
        public DateTime? FechaCambioEstado { get; set; }


        public decimal Kilos { get; set; } 
        public decimal ACuenta { get; set; } 
        public string MetodoPago { get; set; } = "Efectivo"; 

        public decimal Total { get; set; }

        public ICollection<DetallePedido>? Detalles { get; set; }
    }
}
