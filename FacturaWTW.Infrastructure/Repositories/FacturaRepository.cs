using Dapper;
using FacturaWTW.Domain.Contracts;
using FacturaWTW.Domain.Entities;
using FacturaWTW.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FacturaWTW.Infrastructure.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly DbConnectionWTW _db;
        public FacturaRepository(DbConnectionWTW db) => _db = db;

        /// <summary>
        /// Crear una factura con sus detalles
        /// </summary>
        public async Task<int> CrearFacturaAsync(Factura factura)
        {
            using var conn = _db.CreateConnection();
            await ((SqlConnection)conn).OpenAsync();

            using var tx = conn.BeginTransaction();

            try
            {
                // Crear factura
                var facturaId = await conn.QuerySingleAsync<int>(
                    "sp_CrearFactura",
                    new
                    {
                        IdCliente = factura.IdCliente,
                        NumeroFactura = factura.NumeroFactura,
                        NumeroTotalArticulos = factura.NumeroTotalArticulos,
                        SubTotalFacturas = factura.SubTotalFacturas,
                        TotalImpuestos = factura.TotalImpuestos,
                        TotalFactura = factura.TotalFactura
                    },
                    commandType: CommandType.StoredProcedure,
                    transaction: tx
                );

                // Insertar detalles
                foreach (var d in factura.Detalles)
                {
                    await conn.ExecuteAsync(
                        "sp_CrearDetalleFactura",
                        new
                        {
                            IdFactura = facturaId,
                            IdProducto = d.IdProducto,
                            CantidadDeProducto = d.CantidadDeProducto,
                            PrecioUnitarioProducto = d.PrecioUnitarioProducto,
                            SubtotalProducto = d.SubtotalProducto,
                            Notas = d.Notas
                        },
                        commandType: CommandType.StoredProcedure,
                        transaction: tx
                    );
                }

                tx.Commit();
                return facturaId;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }


        /// <summary>
        /// Obtener todas las facturas (sin detalles)
        /// </summary>
        public async Task<IEnumerable<Factura>> BuscarFacturasAsync(int? clienteId, int? facturaId)
        {
            using var conn = _db.CreateConnection();

            var facturas = await conn.QueryAsync<Factura>(
                "sp_BuscarFacturas",
                commandType: CommandType.StoredProcedure
            );

            return facturas;
        }

        /// <summary>
        /// Obtener una factura con sus detalles
        /// </summary>
        public async Task<Factura?> BuscarFacturaByIdAsync(int id)
        {
            using var conn = _db.CreateConnection();

            using var multi = await conn.QueryMultipleAsync(
                "sp_ObtenerFacturaPorId",
                new { IdFactura = id },
                commandType: CommandType.StoredProcedure
            );

            var factura = await multi.ReadSingleOrDefaultAsync<Factura>();
            if (factura != null)
            {
                var detalles = (await multi.ReadAsync<DetalleFactura>()).ToList();
                factura.Detalles = detalles;
            }

            return factura;
        }
    }
}
