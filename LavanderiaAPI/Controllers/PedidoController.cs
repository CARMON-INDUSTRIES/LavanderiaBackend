using LavanderiaAPI.Data;
using LavanderiaAPI.Dto;
using LavanderiaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LavanderiaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> GetPedidos()
        {
            var pedidos = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Detalles)
                .ToListAsync();

            return pedidos.Select(p => new PedidoDto
            {
                Id = p.Id,
                ClienteId = p.ClienteId,
                FechaIngreso = p.FechaIngreso,
                FechaEntrega = p.FechaEntrega,
                Estado = p.Estado,
                FechaCambioEstado = p.FechaCambioEstado,
                Kilos = p.Kilos,
                ACuenta = p.ACuenta,
                MetodoPago = p.MetodoPago,
                Total = p.Total,
                Detalles = p.Detalles?.Select(d => new DetallePedidoDto
                {
                    TipoPrenda = d.TipoPrenda,
                    Servicio = d.Servicio,
                    Precio = d.Precio
                }).ToList()
            }).ToList();
        }

        // GET: api/pedido/ultimo
        [HttpGet("ultimo")]
        public async Task<ActionResult<PedidoDto>> GetUltimoPedido()
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Detalles)
                .OrderByDescending(p => p.Id)
                .FirstOrDefaultAsync();

            if (pedido == null)
                return NotFound();

            var dto = new PedidoDto
            {
                Id = pedido.Id,
                ClienteId = pedido.ClienteId,
                FechaIngreso = pedido.FechaIngreso,
                FechaEntrega = pedido.FechaEntrega,
                Estado = pedido.Estado,
                FechaCambioEstado = pedido.FechaCambioEstado,
                Kilos = pedido.Kilos,
                ACuenta = pedido.ACuenta,
                MetodoPago = pedido.MetodoPago,
                Total = pedido.Total,
                Cliente = pedido.Cliente != null ? new ClienteDto
                {
                    Id = pedido.Cliente.Id,
                    Nombre = pedido.Cliente.Nombre,
                    Telefono = pedido.Cliente.Telefono,
                    Direccion = pedido.Cliente.Direccion
                } : null,
                Detalles = pedido.Detalles?.Select(d => new DetallePedidoDto
                {
                    TipoPrenda = d.TipoPrenda,
                    Servicio = d.Servicio,
                    Precio = d.Precio
                }).ToList()
            };

            return Ok(dto);
        }

        // POST: api/pedido
        [HttpPost]
        public async Task<ActionResult<Pedido>> CreatePedido(PedidoDto pedidoDto)
        {
            var pedido = new Pedido
            {
                ClienteId = pedidoDto.ClienteId,
                FechaIngreso = DateTime.Now,
                FechaEntrega = pedidoDto.FechaEntrega,
                Estado = pedidoDto.Estado,
                Kilos = pedidoDto.Kilos,
                ACuenta = pedidoDto.ACuenta,
                MetodoPago = pedidoDto.MetodoPago,
                Total = pedidoDto.Total,
                Detalles = pedidoDto.Detalles?.Select(d => new DetallePedido
                {
                    TipoPrenda = d.TipoPrenda,
                    Servicio = d.Servicio,
                    Precio = d.Precio
                }).ToList()
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedidos), new { id = pedido.Id }, pedido);
        }

        // PUT: api/pedido/{id}/estado
        [HttpPut("{id}/estado")]
        public async Task<IActionResult> CambiarEstado(int id, [FromBody] EstadoDto dto)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
                return NotFound();

            pedido.Estado = dto.NuevoEstado;
            pedido.FechaCambioEstado = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                pedido.Id,
                pedido.Estado,
                pedido.FechaCambioEstado
            });
        }

        public class EstadoDto
        {
            public string NuevoEstado { get; set; }
        }
    }
}
