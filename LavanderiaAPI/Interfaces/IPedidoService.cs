using LavanderiaAPI.Dto;

namespace LavanderiaAPI.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoDto>> GetAllAsync();
        Task<PedidoDto?> GetByIdAsync(int id);
        Task<PedidoDto> CreateAsync(PedidoCreateDto dto);
        Task<bool> UpdateEstadoAsync(int id, string nuevoEstado);
        Task<bool> DeleteAsync(int id);
    }
}
