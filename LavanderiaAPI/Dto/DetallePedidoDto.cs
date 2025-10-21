namespace LavanderiaAPI.Dto
{
    public class DetallePedidoDto
    {
        public int PedidoId { get; set; } // 🔥 Agregado
        public string TipoPrenda { get; set; } = string.Empty;
        public string Servicio { get; set; } = string.Empty;
        public decimal Precio { get; set; }
    }
}
