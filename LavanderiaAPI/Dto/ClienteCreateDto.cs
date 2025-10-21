namespace LavanderiaAPI.Dto
{
    public class ClienteCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string? Direccion { get; set; }
    }
}
