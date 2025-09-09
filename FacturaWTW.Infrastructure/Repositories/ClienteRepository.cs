using Dapper;
using FacturaWTW.Domain.Contracts;
using FacturaWTW.Domain.Entities;
using FacturaWTW.Infrastructure.Data;
using System.Data;

namespace FacturaWTW.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbConnectionWTW _db;
        public ClienteRepository(DbConnectionWTW db) => _db = db;

        public async Task<IEnumerable<Cliente>> BuscarClientes()
        {
            using var conn = _db.CreateConnection();
            return await conn.QueryAsync<Cliente>("sp_ObtenerClientes", commandType: CommandType.StoredProcedure);
        }

        public async Task<Cliente?> BuscarClientesPorId(int id)
        {
            using var conn = _db.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<Cliente>("sp_ObtenerClientePorId", new { ClienteId = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CrearClienteAsync(Cliente cliente)
        {
            using var conn = _db.CreateConnection();
            return await conn.QuerySingleAsync<int>(
                "sp_CrearCliente",
                new { cliente.RazonSocial, cliente.IdTipoCliente, cliente.RFC },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> ActualizarClienteAsync(Cliente cliente)
        {
            using var conn = _db.CreateConnection();
            var rows = await conn.ExecuteAsync(
                "sp_ActualizarCliente",
                new { cliente.Id, cliente.RazonSocial, cliente.IdTipoCliente, cliente.RFC },
                commandType: CommandType.StoredProcedure);
            return rows > 0;
        }
    }
}
