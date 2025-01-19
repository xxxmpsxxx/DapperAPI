using Dapper;
using DapperAPI.Data;
using DapperAPI.Model;

namespace DapperAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private DbSession _dbSession;

        public ClienteRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = _dbSession.Connection)
            {
                string command = @"
                    DELETE FROM Clientes WHERE Id = @id";
                var result = await conn.ExecuteAsync(sql: command, param: new { id });
                return result;
            }
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            using (var conn = _dbSession.Connection)
            {
                string query = "SELECT * FROM Clientes WHERE Id = @id";
                Cliente cliente = await conn.QueryFirstOrDefaultAsync<Cliente>(sql: query, param: new { id });
                return cliente;
            }
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            using (var conn = _dbSession.Connection)
            {
                string query = "SELECT * FROM Clientes";
                List<Cliente> clientes = (await conn.QueryAsync<Cliente>(sql: query)).ToList();
                return clientes;
            }
        }

        public async Task<ClienteContainer> GetClientesEContadorAsync()
        {
            using (var conn = _dbSession.Connection)
            {
                string query = @"SELECT COUNT(*) FROM Clientes
                                 SELECT * FROM Clientes";
                var reader = await conn.QueryMultipleAsync(sql: query);

                return new ClienteContainer
                {
                    Contador = (await reader.ReadAsync<int>()).FirstOrDefault(),
                    Clientes = (await reader.ReadAsync<Cliente>()).ToList()
                };
            }
        }

        public async Task<int> SaveAsync(Cliente instance)
        {
            using (var conn = _dbSession.Connection)
            {
                string command = @"
                    INSERT INTO Clientes(Nome, CPF, Telefone, IsAtivo)
                    VALUES(@Nome, @CPF, @Telefone, @IsAtivo)";
                var result = await conn.ExecuteAsync(sql: command, param: instance);
                return result;
            }
        }

        public async Task<int> UpdateClienteStatusAsync(Cliente instance)
        {
            using (var conn = _dbSession.Connection)
            {
                string command = @"
                    UPDATE Clientes SET IsAtivo = @IsAtivo WHERE Id = @Id";
                var result = await conn.ExecuteAsync(sql: command, param: instance);
                return result;
            }
        }
    }
}
