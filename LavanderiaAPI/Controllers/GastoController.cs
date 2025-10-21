using LavanderiaAPI.Dto;
using LavanderiaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LavanderiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GastoController : ControllerBase
    {
        private readonly IGastoService _service;

        public GastoController(IGastoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GastoDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GastoDto>> GetById(int id)
        {
            var gasto = await _service.GetByIdAsync(id);
            if (gasto == null) return NotFound();
            return Ok(gasto);
        }

        [HttpPost]
        public async Task<ActionResult<GastoDto>> Create(GastoCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
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
