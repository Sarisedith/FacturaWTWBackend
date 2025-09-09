using FacturaWTW.Application.DTOs;
using FacturaWTW.Domain.Entities;
using System.Threading.Tasks;

namespace FacturaWTW.Application.Services
{
    public interface IFacturaService
    {
        Task<int> CrearFacturaAsync(FacturaCreateDTO dto);
        Task<Factura?> BuscarFacturaByIdAsync(int id);
        Task<IEnumerable<Factura>> BuscarFacturasAsync(int? clienteId, int? facturaId);
    }
}
