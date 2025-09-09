using AutoMapper;
using FacturaWTW.Application.DTOs;
using FacturaWTW.Domain.Contracts;
using FacturaWTW.Domain.Entities;

namespace FacturaWTW.Application.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _repo;
        private readonly IMapper _mapper;

        public FacturaService(IFacturaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Crear una factura y calcular totales
        /// </summary>
        public async Task<int> CrearFacturaAsync(FacturaCreateDTO dto)
        {
            var factura = _mapper.Map<Factura>(dto);

            // Calcular subtotal por cada detalle
            foreach (var d in factura.Detalles)
            {
                d.SubtotalProducto = d.PrecioUnitarioProducto * d.CantidadDeProducto;
            }

            // Calcular totales de la factura
            factura.NumeroTotalArticulos = factura.Detalles.Sum(x => x.CantidadDeProducto);
            factura.SubTotalFacturas = factura.Detalles.Sum(x => x.SubtotalProducto);
            factura.TotalImpuestos = decimal.Round(factura.SubTotalFacturas * 0.19m, 2); // IVA 19%
            factura.TotalFactura = factura.SubTotalFacturas + factura.TotalImpuestos;

            return await _repo.CrearFacturaAsync(factura);
        }

        /// <summary>
        /// Obtener factura por Id
        /// </summary>
        public async Task<Factura?> BuscarFacturaByIdAsync(int id) => await _repo.BuscarFacturaByIdAsync(id);

        /// <summary>
        /// Obtener todas las facturas
        /// </summary>
        public async Task<IEnumerable<Factura>> BuscarFacturasAsync(int? clienteId, int? facturaId) => await _repo.BuscarFacturasAsync(clienteId, facturaId);
    }
}
