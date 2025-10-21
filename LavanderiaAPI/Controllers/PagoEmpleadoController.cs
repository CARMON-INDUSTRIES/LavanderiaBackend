using LavanderiaAPI.Dto;
using LavanderiaAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LavanderiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoEmpleadoController : ControllerBase
    {
        private readonly IPagoEmpleadoService _service;

        public PagoEmpleadoController(IPagoEmpleadoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pagos = await _service.GetAllAsync();
            return Ok(pagos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pago = await _service.GetByIdAsync(id);
            if (pago == null) return NotFound();
            return Ok(pago);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PagoEmpleadoDto dto)
        {
            var nuevoPago = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevoPago.Id }, nuevoPago);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.DeleteAsync(id);
            return eliminado ? NoContent() : NotFound();
        }
    }

}
