﻿namespace LavanderiaAPI.Dto
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string? Direccion { get; set; }
    }
}
