using LavanderiaAPI.Data;
using LavanderiaAPI.Dto;
using LavanderiaAPI.Interfaces;
using LavanderiaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LavanderiaAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            return await _context.Clientes
                .Select(c => new ClienteDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Telefono = c.Telefono,
                    Direccion = c.Direccion
                }).ToListAsync();
        }

        public async Task<ClienteDto?> GetByIdAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return null;

            return new ClienteDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion
            };
        }

        public async Task<ClienteDto> CreateAsync(ClienteCreateDto dto)
        {
            var cliente = new Cliente
            {
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return new ClienteDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion
            };
        }

        public async Task<bool> UpdateAsync(int id, ClienteCreateDto dto)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            cliente.Nombre = dto.Nombre;
            cliente.Telefono = dto.Telefono;
            cliente.Direccion = dto.Direccion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
