using LavanderiaAPI.Dto;
using LavanderiaAPI.Models;
using LavanderiaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LavanderiaAPI.Services
{
    public class DetallePedidoService
    {
        private readonly AppDbContext _context;

        public DetallePedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetallePedido>> GetAllAsync()
        {
            return await _context.DetallesPedido.Include(d => d.Pedido).ToListAsync();
        }

        public async Task<DetallePedido?> GetByIdAsync(int id)
        {
            return await _context.DetallesPedido
                .Include(d => d.Pedido)
                .FirstOrDefaultAsync(d => d.PedidoId == id);
        }

        public async Task<DetallePedido> CreateAsync(DetallePedidoDto dto)
        {
            var detalle = new DetallePedido
            {
                PedidoId = dto.PedidoId,
                TipoPrenda = dto.TipoPrenda,
                Servicio = dto.Servicio,
                Precio = dto.Precio
            };

            _context.DetallesPedido.Add(detalle);
            await _context.SaveChangesAsync();
            return detalle;
        }

        public async Task<bool> UpdateAsync(int id, DetallePedidoDto dto)
        {
            var detalle = await _context.DetallesPedido.FindAsync(id);
            if (detalle == null) return false;

            detalle.PedidoId = dto.PedidoId;
            detalle.TipoPrenda = dto.TipoPrenda;
            detalle.Servicio = dto.Servicio;
            detalle.Precio = dto.Precio;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var detalle = await _context.DetallesPedido.FindAsync(id);
            if (detalle == null) return false;

            _context.DetallesPedido.Remove(detalle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
