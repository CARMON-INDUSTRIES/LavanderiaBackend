using LavanderiaAPI.Dto;

namespace LavanderiaAPI.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> GetAllAsync();
        Task<ClienteDto?> GetByIdAsync(int id);
        Task<ClienteDto> CreateAsync(ClienteCreateDto dto);
        Task<bool> UpdateAsync(int id, ClienteCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
