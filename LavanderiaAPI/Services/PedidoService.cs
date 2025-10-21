using LavanderiaAPI.Data;
using LavanderiaAPI.Dto;
using LavanderiaAPI.Interfaces;
using LavanderiaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LavanderiaAPI.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly AppDbContext _context;

        public PedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PedidoDto>> GetAllAsync()
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Detalles)
                .Select(p => new PedidoDto
                {
                    Id = p.Id,
                    FechaIngreso = p.FechaIngreso,
                    FechaEntrega = p.FechaEntrega,
                    Estado = p.Estado,
                    Total = p.Total,
                    Cliente = new ClienteDto
                    {
                        Id = p.Cliente!.Id,
                        Nombre = p.Cliente.Nombre,
                        Telefono = p.Cliente.Telefono,
                        Direccion = p.Cliente.Direccion
                    },
                    Detalles = p.Detalles!.Select(d => new DetallePedidoDto
                    {
                        TipoPrenda = d.TipoPrenda,
                        Servicio = d.Servicio,
                        Precio = d.Precio
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<PedidoDto?> GetByIdAsync(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Detalles)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null) return null;

            return new PedidoDto
            {
                Id = pedido.Id,
                FechaIngreso = pedido.FechaIngreso,
                FechaEntrega = pedido.FechaEntrega,
                Estado = pedido.Estado,
                Total = pedido.Total,
                Cliente = new ClienteDto
                {
                    Id = pedido.Cliente!.Id,
                    Nombre = pedido.Cliente.Nombre,
                    Telefono = pedido.Cliente.Telefono,
                    Direccion = pedido.Cliente.Direccion
                },
                Detalles = pedido.Detalles!.Select(d => new DetallePedidoDto
                {
                    TipoPrenda = d.TipoPrenda,
                    Servicio = d.Servicio,
                    Precio = d.Precio
                }).ToList()
            };
        }

        public async Task<PedidoDto> CreateAsync(PedidoCreateDto dto)
        {
            var detalles = dto.Detalles.Select(d => new DetallePedido
            {
                TipoPrenda = d.TipoPrenda,
                Servicio = d.Servicio,
                Precio = d.Precio
            }).ToList();

            var total = detalles.Sum(d => d.Precio);

            var pedido = new Pedido
            {
                ClienteId = dto.ClienteId,
                FechaIngreso = DateTime.Now, 
                FechaEntrega = dto.FechaEntrega,
                Estado = "Recibido",
                Total = total,
                Detalles = detalles
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(pedido.Id) ?? throw new Exception("Error al crear pedido");
        }


        public async Task<bool> UpdateEstadoAsync(int id, string nuevoEstado)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null) return false;

            pedido.Estado = nuevoEstado;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pedido = await _context.Pedidos.Include(p => p.Detalles).FirstOrDefaultAsync(p => p.Id == id);
            if (pedido == null) return false;

            _context.DetallesPedido.RemoveRange(pedido.Detalles!);
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
