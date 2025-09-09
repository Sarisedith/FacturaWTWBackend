using FacturaWTW.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacturaWTW.Domain.Contracts
{
    public interface IFacturaRepository
    {
        Task<int> CrearFacturaAsync(Factura factura);
        Task<Factura?> BuscarFacturaByIdAsync(int id);
        Task<IEnumerable<Factura>> BuscarFacturasAsync(int? clienteId, int? facturaId);
    }
}
