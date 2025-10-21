namespace LavanderiaAPI.Dto
{
    public class GastoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string? Categoria { get; set; }
    }
}
