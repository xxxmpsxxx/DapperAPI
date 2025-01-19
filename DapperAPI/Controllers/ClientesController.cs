using DapperAPI.Model;
using DapperAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [Route("clientes")]
        public async Task<IActionResult> GetClientesAsync()
        {
            var result = await _clienteRepository.GetClientesAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("cliente")]
        public async Task<IActionResult> GetClienteByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            return Ok(cliente);
        }

        [HttpGet]
        [Route("clientescontador")]
        public async Task<IActionResult> GetClienteEContadorAsync()
        {
            var result = await _clienteRepository.GetClientesEContadorAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("criarcliente")]
        public async Task<IActionResult> SaveAsync(Cliente instance)
        {
            var result = await _clienteRepository.SaveAsync(instance);
            return Ok(result);
        }

        [HttpPost()]
        [Route("atualizarstatus")]
        public async Task<IActionResult> UpdateClienteStatusAsync(Cliente instance)
        {
            var result = await _clienteRepository.UpdateClienteStatusAsync(instance);
            return Ok(result);
        }

        [HttpDelete]
        [Route("excluircliente")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _clienteRepository.DeleteAsync(id);
            return Ok(result);
        }
    }
}
