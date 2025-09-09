using FacturaWTW.Application.DTOs;
namespace FacturaWTW.Application.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> BuscarClientes();
        Task<ClienteDTO?> BuscarClientesPorId(int id);
        Task<int> CrearClienteAsync(ClienteCreateDTO dto);
        Task<bool> ActualizarClienteAsync(ClienteUpdateDTO dto);
    }
}
