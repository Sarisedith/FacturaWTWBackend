using Dapper;
using FacturaWTW.Domain.Contracts;
using FacturaWTW.Domain.Entities;
using FacturaWTW.Infrastructure.Data;
using System.Data;

namespace FacturaWTW.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DbConnectionWTW _db;
        public ProductoRepository(DbConnectionWTW db) => _db = db;

        public async Task<IEnumerable<CatProducto>> ObtenerTodosAsync()
        {
            using var conn = _db.CreateConnection();
            return await conn.QueryAsync<CatProducto>(
                "sp_ObtenerProductos",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<CatProducto?> ObtenerPorIdAsync(int id)
        {
            using var conn = _db.CreateConnection();
            return await conn.QuerySingleOrDefaultAsync<CatProducto>(
                "sp_ObtenerProductoPorId",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> CrearAsync(CatProducto producto)
        {
            using var conn = _db.CreateConnection();
            return await conn.QuerySingleAsync<int>(
                "sp_CrearProducto",
                new
                {
                    producto.NombreProducto,
                    producto.ImagenProducto,
                    producto.PrecioUnitario,
                    producto.Ext
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<bool> ActualizarAsync(CatProducto producto)
        {
            using var conn = _db.CreateConnection();
            var rows = await conn.ExecuteScalarAsync<int>(
                "sp_ActualizarProducto",
                new
                {
                    producto.Id,
                    producto.NombreProducto,
                    producto.ImagenProducto,
                    producto.PrecioUnitario,
                    producto.Ext
                },
                commandType: CommandType.StoredProcedure
            );
            return rows > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            using var conn = _db.CreateConnection();
            var rows = await conn.ExecuteScalarAsync<int>(
                "sp_EliminarProducto",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
            return rows > 0;
        }
    }
}
