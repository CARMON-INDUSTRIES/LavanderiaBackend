using LavanderiaAPI.Dto;
using LavanderiaAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LavanderiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   // [Authorize(Roles = "Admin")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteCreateDto dto)
        {
            var nuevo = await _clienteService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClienteCreateDto dto)
        {
            var updated = await _clienteService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _clienteService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
