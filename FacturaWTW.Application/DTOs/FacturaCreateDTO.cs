using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturaWTW.Application.DTOs
{
    public class FacturaCreateDTO
    {
        public int IdCliente { get; set; }
        public int NumeroFactura { get; set; }
        public List<DetalleFacturaDTO> Detalles { get; set; } = new();
    }
}
