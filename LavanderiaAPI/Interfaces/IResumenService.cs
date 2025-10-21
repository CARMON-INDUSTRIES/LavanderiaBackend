using LavanderiaAPI.Dto;

namespace LavanderiaAPI.Interfaces
{
    public interface IResumenService
    {
        Task<ResumenSemanalDto?> GenerarResumenAsync(ResumenSemanalCreateDto dto);
        Task<IEnumerable<ResumenSemanalDto>> GetHistorialAsync();
        Task<ResumenSemanalDto?> GetByIdAsync(int id);
    }
}
