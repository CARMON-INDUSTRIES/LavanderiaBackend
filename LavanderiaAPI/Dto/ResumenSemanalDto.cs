namespace LavanderiaAPI.Dto
{
    public class ResumenSemanalDto
    {
        public int Id { get; set; }
        public DateTime SemanaInicio { get; set; }
        public DateTime SemanaFin { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalGastos { get; set; }
        public int PedidosCompletados { get; set; }
        public int PagosRealizados { get; set; }
        public DateTime FechaGeneracion { get; set; }
    }
}
