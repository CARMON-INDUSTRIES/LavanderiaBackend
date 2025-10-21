using LavanderiaAPI.Dto;

namespace LavanderiaAPI.Services
{
    public interface IGastoService
    {
        Task<List<GastoDto>> GetAllAsync();
        Task<GastoDto?> GetByIdAsync(int id);
        Task<GastoDto> CreateAsync(GastoCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
