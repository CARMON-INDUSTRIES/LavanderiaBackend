namespace LavanderiaAPI.Dto
{
    public class ResumenSemanalCreateDto
    {
        public DateTime SemanaInicio { get; set; }
        public DateTime SemanaFin { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalGastos { get; set; }
        public int PedidosCompletados { get; set; }
        public int PagosRealizados { get; set; }
    }
}
