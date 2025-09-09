using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaWTW.Application.DTOs
{
    public class ProductoActualizarDTO
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; }
        public byte[]? ImagenProducto { get; set; }
        public string? Ext { get; set; }
    }
}
