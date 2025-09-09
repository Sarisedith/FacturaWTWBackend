using FacturaWTW.Domain.Entities;
namespace FacturaWTW.Domain.Contracts
{
    public interface IProductoRepository
    {
        Task<IEnumerable<CatProducto>> ObtenerTodosAsync();
        Task<CatProducto?> ObtenerPorIdAsync(int id);
        Task<int> CrearAsync(CatProducto producto);
        Task<bool> ActualizarAsync(CatProducto producto);
        Task<bool> EliminarAsync(int id);
    }
}
