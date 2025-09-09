using FacturaWTW.Domain.Entities;
namespace FacturaWTW.Domain.Contracts
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> BuscarClientes();
        Task<Cliente?> BuscarClientesPorId(int id);
        Task<int> CrearClienteAsync(Cliente cliente);
        Task<bool> ActualizarClienteAsync(Cliente cliente);
    }
}
