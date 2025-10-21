namespace LavanderiaAPI.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string? Categoria { get; set; } // Ej. Insumos, Servicios, Renta, etc.
    }
}
