namespace LavanderiaAPI.Dto
{
    public class PagoEmpleadoCreateDto
    {
        public string NombreEmpleado { get; set; } = string.Empty;
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string? Observaciones { get; set; }
    }
}
