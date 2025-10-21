using LavanderiaAPI.Data;
using LavanderiaAPI.Dto;
using LavanderiaAPI.Interfaces;
using LavanderiaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LavanderiaAPI.Services
{
    public class PagoEmpleadoService : IPagoEmpleadoService
    {
        private readonly AppDbContext _context;

        public PagoEmpleadoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PagoEmpleado>> GetAllAsync()
        {
            return await _context.PagosEmpleados.ToListAsync();
        }

        public async Task<PagoEmpleado?> GetByIdAsync(int id)
        {
            return await _context.PagosEmpleados.FindAsync(id);
        }

        public async Task<PagoEmpleado> CreateAsync(PagoEmpleadoDto dto)
        {
            var pago = new PagoEmpleado
            {
                NombreEmpleado = dto.NombreEmpleado,
                FechaPago = dto.FechaPago,
                Monto = dto.Monto,
                Observaciones = dto.Observaciones
            };

            _context.PagosEmpleados.Add(pago);
            await _context.SaveChangesAsync();

            return pago;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pago = await _context.PagosEmpleados.FindAsync(id);
            if (pago == null) return false;

            _context.PagosEmpleados.Remove(pago);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
