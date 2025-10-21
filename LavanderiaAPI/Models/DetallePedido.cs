using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LavanderiaAPI.Models
{
    public class DetallePedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }

        [JsonIgnore]
        public Pedido? Pedido { get; set; }

        public string TipoPrenda { get; set; } = string.Empty;
        public string Servicio { get; set; } = string.Empty;
        public decimal Precio { get; set; }
    }
}
