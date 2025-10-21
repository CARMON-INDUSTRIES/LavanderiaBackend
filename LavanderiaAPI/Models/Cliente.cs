namespace LavanderiaAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
