using FacturaWTW.Domain.Entities;
namespace FacturaWTW.Domain.Contracts
{
    public interface ITipoClienteRepository
    {
        Task<IEnumerable<CatTipoCliente>> ObtenerTodosAsync();
        Task<CatTipoCliente?> ObtenerPorIdAsync(int id);
        Task<int> CrearAsync(CatTipoCliente tipo);
        Task<bool> ActualizarAsync(CatTipoCliente tipo);
        Task<bool> EliminarAsync(int id);
    }
}
