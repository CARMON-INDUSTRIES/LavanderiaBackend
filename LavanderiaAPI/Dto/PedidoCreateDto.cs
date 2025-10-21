namespace LavanderiaAPI.Dto
{
    public class PedidoCreateDto
    {
        public int ClienteId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEntrega { get; set; }
        public List<DetallePedidoDto> Detalles { get; set; } = new();
    }
}
