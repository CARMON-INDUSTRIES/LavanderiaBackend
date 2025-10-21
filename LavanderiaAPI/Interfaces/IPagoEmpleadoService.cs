using LavanderiaAPI.Dto;
using LavanderiaAPI.Models;

namespace LavanderiaAPI.Interfaces
{
    public interface IPagoEmpleadoService
    {
        Task<List<PagoEmpleado>> GetAllAsync();
        Task<PagoEmpleado?> GetByIdAsync(int id);
        Task<PagoEmpleado> CreateAsync(PagoEmpleadoDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
