using Dapper;
using FacturaWTW.Domain.Contracts;
using FacturaWTW.Domain.Entities;
using FacturaWTW.Infrastructure.Data;
using System.Data;


namespace FacturaWTW.Infrastructure.Repositories
{
    public class TipoClienteRepository : ITipoClienteRepository
    {
        private readonly DbConnectionWTW _db;
        public TipoClienteRepository(DbConnectionWTW db) => _db = db;

        public async Task<IEnumerable<CatTipoCliente>> ObtenerTodosAsync()
        {
            using var conn = _db.CreateConnection();
            return await conn.QueryAsync<CatTipoCliente>(
                "sp_ObtenerTiposCliente",
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<CatTipoCliente?> ObtenerPorIdAsync(int id)
        {
            using var conn = _db.CreateConnection();
            return await conn.QuerySingleOrDefaultAsync<CatTipoCliente>(
                "sp_ObtenerTipoClientePorId",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> CrearAsync(CatTipoCliente tipo)
        {
            using var conn = _db.CreateConnection();
            return await conn.QuerySingleAsync<int>(
                "sp_CrearTipoCliente",
                new { TipoCliente = tipo.TipoCliente },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<bool> ActualizarAsync(CatTipoCliente tipo)
        {
            using var conn = _db.CreateConnection();
            var rows = await conn.ExecuteScalarAsync<int>(
                "sp_ActualizarTipoCliente",
                new { Id = tipo.Id, TipoCliente = tipo.TipoCliente },
                commandType: CommandType.StoredProcedure
            );
            return rows > 0;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            using var conn = _db.CreateConnection();
            var rows = await conn.ExecuteScalarAsync<int>(
                "sp_EliminarTipoCliente",
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
            return rows > 0;
        }
    }
}
