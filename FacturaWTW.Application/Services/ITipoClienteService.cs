using FacturaWTW.Application.DTOs;
namespace FacturaWTW.Application.Services
{
    public interface ITipoClienteService
    {
        Task<IEnumerable<TipoClienteDTO>> ObtenerTodosAsync();
        Task<TipoClienteDTO?> ObtenerPorIdAsync(int id);
        Task<int> CrearAsync(TipoClienteCrearDTO dto);
        Task<bool> ActualizarAsync(TipoClienteActualizarDTO dto);
        Task<bool> EliminarAsync(int id);
    }
}
