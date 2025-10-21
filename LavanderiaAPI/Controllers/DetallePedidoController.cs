using LavanderiaAPI.Dto;
using LavanderiaAPI.Models;
using LavanderiaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LavanderiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetallePedidoController : ControllerBase
    {
        private readonly DetallePedidoService _service;

        public DetallePedidoController(DetallePedidoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetById(int id)
        {
            var detalle = await _service.GetByIdAsync(id);
            if (detalle == null) return NotFound();
            return Ok(detalle);
        }

        [HttpPost]
        public async Task<ActionResult<DetallePedido>> Create([FromBody] DetallePedidoDto dto)
        {
            var detalle = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = detalle.PedidoId }, detalle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DetallePedidoDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
