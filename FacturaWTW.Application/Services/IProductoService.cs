using FacturaWTW.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaWTW.Application.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDTO>> ObtenerTodosAsync();
        Task<ProductoDTO?> ObtenerPorIdAsync(int id);
        Task<int> CrearAsync(ProductoCrearDTO dto);
        Task<bool> ActualizarAsync(ProductoActualizarDTO dto);
        Task<bool> EliminarAsync(int id);
    }
}
