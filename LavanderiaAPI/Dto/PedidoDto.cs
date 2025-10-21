using System;
using System.Collections.Generic;

namespace LavanderiaAPI.Dto
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public ClienteDto Cliente { get; set; } = new ClienteDto();
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Estado { get; set; } = "Pendiente";
        public decimal Kilos { get; set; }
        public decimal ACuenta { get; set; }
        public string MetodoPago { get; set; } = "Efectivo";
        public decimal Total { get; set; }

        public List<DetallePedidoDto>? Detalles { get; set; }
    }
}
