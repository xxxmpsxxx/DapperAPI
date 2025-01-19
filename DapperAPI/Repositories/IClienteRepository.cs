using DapperAPI.Model;

namespace DapperAPI.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<ClienteContainer> GetClientesEContadorAsync();
        Task<int> SaveAsync(Cliente instance);
        Task<int> UpdateClienteStatusAsync(Cliente instance);
        Task<int> DeleteAsync(int id);
    }
}
