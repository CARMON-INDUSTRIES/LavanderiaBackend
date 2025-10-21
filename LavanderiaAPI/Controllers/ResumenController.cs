using LavanderiaAPI.Dto;
using LavanderiaAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LavanderiaERP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class ResumenController : ControllerBase
    {
        private readonly IResumenService _service;

        public ResumenController(IResumenService service)
        {
            _service = service;
        }

        [HttpPost("generar")]
        public async Task<IActionResult> Generar(ResumenSemanalCreateDto dto)
        {
            var resumen = await _service.GenerarResumenAsync(dto);
            if (resumen == null)
                return Conflict("Ya existe un resumen para esta semana.");

            return CreatedAtAction(nameof(GetById), new { id = resumen.Id }, resumen);
        }

        [HttpGet]
        public async Task<IActionResult> GetHistorial()
        {
            var lista = await _service.GetHistorialAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resumen = await _service.GetByIdAsync(id);
            return resumen == null ? NotFound() : Ok(resumen);
        }
    }
}
