namespace LavanderiaAPI.Dto
{
    public class PagoEmpleadoDto
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; } = string.Empty;
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string? Observaciones { get; set; }
    }
}
