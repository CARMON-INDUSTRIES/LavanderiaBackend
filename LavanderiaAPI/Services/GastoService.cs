using LavanderiaAPI.Data;
using LavanderiaAPI.Dto;
using LavanderiaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LavanderiaAPI.Services
{
    public class GastoService : IGastoService
    {
        private readonly AppDbContext _context;

        public GastoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GastoDto>> GetAllAsync()
        {
            return await _context.Gastos
                .Select(g => new GastoDto
                {
                    Id = g.Id,
                    Descripcion = g.Descripcion,
                    Monto = g.Monto,
                    Fecha = g.Fecha,
                    Categoria = g.Categoria
                }).ToListAsync();
        }

        public async Task<GastoDto?> GetByIdAsync(int id)
        {
            var gasto = await _context.Gastos.FindAsync(id);
            if (gasto == null) return null;

            return new GastoDto
            {
                Id = gasto.Id,
                Descripcion = gasto.Descripcion,
                Monto = gasto.Monto,
                Fecha = gasto.Fecha,
                Categoria = gasto.Categoria
            };
        }

        public async Task<GastoDto> CreateAsync(GastoCreateDto dto)
        {
            var gasto = new Gasto
            {
                Descripcion = dto.Descripcion,
                Monto = dto.Monto,
                Fecha = dto.Fecha,
                Categoria = dto.Categoria
            };

            _context.Gastos.Add(gasto);
            await _context.SaveChangesAsync();

            return new GastoDto
            {
                Id = gasto.Id,
                Descripcion = gasto.Descripcion,
                Monto = gasto.Monto,
                Fecha = gasto.Fecha,
                Categoria = gasto.Categoria
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var gasto = await _context.Gastos.FindAsync(id);
            if (gasto == null) return false;

            _context.Gastos.Remove(gasto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
