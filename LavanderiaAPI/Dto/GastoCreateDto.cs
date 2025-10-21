namespace LavanderiaAPI.Dto
{
    public class GastoCreateDto
    {
        public string Descripcion { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string? Categoria { get; set; }
    }
}
