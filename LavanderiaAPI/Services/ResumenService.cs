using LavanderiaAPI.Data;
using LavanderiaAPI.Dto;
using LavanderiaAPI.Interfaces;
using LavanderiaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LavanderiaERP.Services
{
    public class ResumenService : IResumenService
    {
        private readonly AppDbContext _context;

        public ResumenService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResumenSemanalDto?> GenerarResumenAsync(ResumenSemanalCreateDto dto)
        {
            // Evitar duplicados
            bool existe = await _context.ResumenesSemanales
                .AnyAsync(r => r.SemanaInicio == dto.SemanaInicio && r.SemanaFin == dto.SemanaFin);

            if (existe) return null;

            // Total de pedidos completados (estado = "Completado")
            var pedidosCompletados = await _context.Pedidos
                .Where(p => p.Estado == "Completado"
                         && p.FechaEntrega >= dto.SemanaInicio
                         && p.FechaEntrega <= dto.SemanaFin)
                .ToListAsync();

            var ingresos = pedidosCompletados.Sum(p => p.Total);

            // Gastos generales
            var gastos = await _context.Gastos
                .Where(g => g.Fecha >= dto.SemanaInicio && g.Fecha <= dto.SemanaFin)
                .SumAsync(g => g.Monto);

            // Pagos a empleados
            var pagos = await _context.PagosEmpleados
                .Where(p => p.FechaPago >= dto.SemanaInicio && p.FechaPago <= dto.SemanaFin)
                .ToListAsync();

            var montoPagado = pagos.Sum(p => p.Monto);
            var cantidadPagos = pagos.Count;

            var resumen = new ResumenSemanal
            {
                SemanaInicio = dto.SemanaInicio,
                SemanaFin = dto.SemanaFin,
                TotalIngresos = ingresos,
                TotalGastos = gastos + montoPagado,
                PedidosCompletados = pedidosCompletados.Count,
                PagosRealizados = cantidadPagos,
                FechaGeneracion = DateTime.UtcNow
            };

            _context.ResumenesSemanales.Add(resumen);
            await _context.SaveChangesAsync();

            return new ResumenSemanalDto
            {
                Id = resumen.Id,
                SemanaInicio = resumen.SemanaInicio,
                SemanaFin = resumen.SemanaFin,
                TotalIngresos = resumen.TotalIngresos,
                TotalGastos = resumen.TotalGastos,
                PedidosCompletados = resumen.PedidosCompletados,
                PagosRealizados = resumen.PagosRealizados,
                FechaGeneracion = resumen.FechaGeneracion
            };
        }

        public async Task<IEnumerable<ResumenSemanalDto>> GetHistorialAsync()
        {
            return await _context.ResumenesSemanales
                .OrderByDescending(r => r.SemanaInicio)
                .Select(r => new ResumenSemanalDto
                {
                    Id = r.Id,
                    SemanaInicio = r.SemanaInicio,
                    SemanaFin = r.SemanaFin,
                    TotalIngresos = r.TotalIngresos,
                    TotalGastos = r.TotalGastos,
                    PedidosCompletados = r.PedidosCompletados,
                    PagosRealizados = r.PagosRealizados,
                    FechaGeneracion = r.FechaGeneracion
                }).ToListAsync();
        }

        public async Task<ResumenSemanalDto?> GetByIdAsync(int id)
        {
            var r = await _context.ResumenesSemanales.FindAsync(id);
            if (r == null) return null;

            return new ResumenSemanalDto
            {
                Id = r.Id,
                SemanaInicio = r.SemanaInicio,
                SemanaFin = r.SemanaFin,
                TotalIngresos = r.TotalIngresos,
                TotalGastos = r.TotalGastos,
                PedidosCompletados = r.PedidosCompletados,
                PagosRealizados = r.PagosRealizados,
                FechaGeneracion = r.FechaGeneracion
            };
        }
    }
}
