using ForlogicAutoAvaliacao.Domain.Entities;
using ForlogicAutoAvaliacao.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace ForlogicAutoAvaliacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        protected readonly ILogger<AvaliacoesController> _logger;
        public ClientesController(ILogger<AvaliacoesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes(
            [FromServices] IClienteService _clienteService)
        {
            var clientes = await _clienteService.GetAll();
            if (clientes.Count() == 0)
            {
                _logger.LogInformation("Não existe clientes cadastrados!");
                return NoContent();
            }

            return Ok(clientes.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(
            int id,
            [FromServices] IClienteService _clienteService)
        {
            var cliente = await _clienteService.GetById(id);
            if (cliente == null)
            {
                _logger.LogWarning($"Cliente não encontrado para o id:{id} informado!");
                return NotFound($"Cliente não encontrado para id:{id} informado!");
            }

            return Ok(cliente);
        }

        [HttpGet("clientes_by_name")]
        public async Task<IActionResult> GetClientesByName(
         [FromServices] IClienteService _clienteService)
        {
            var clientes = await _clienteService.ClientesByName();
            if (clientes.Count() == 0)
            {
                _logger.LogInformation("Não existe clientes cadastrados!");
                return NoContent();
            }

            return Ok(clientes.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> PostCliente(
            [FromBody] Cliente cliente,
            [FromServices] IClienteService _clienteService)
        {
            if (_clienteService.IsExistCnpj(cliente.Cnpj))
            {
                _logger.LogWarning($"Cnpj {cliente.Cnpj} já encontra-se cadastrado!");
                return NotFound($"Cnpj {cliente.Cnpj} já encontra-se cadastrado!");
            }

            _logger.LogInformation($"Cliente sendo inserida. Segue dados a serem inseridos: {cliente}");
            await _clienteService.Insert(cliente);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutCliente(
            Cliente cliente,
            [FromServices] IClienteService _clienteService)
        {
            var clienteBase = _clienteService.GetById(cliente.Id).Result;
            if (clienteBase == null)
            {
                _logger.LogWarning($"Cliente não encontrado para o id:{cliente.Id} informado!");
                return NotFound($"Cliente de id:{cliente.Id} não foi encontrado!");
            }

            if (clienteBase.Cnpj != cliente.Cnpj)
            {
                if (_clienteService.IsExistCnpj(cliente.Cnpj))
                {
                    _logger.LogWarning($"Cnpj {cliente.Cnpj} já encontra-se cadastrado!");
                    return NotFound($"Cnpj {cliente.Cnpj} já encontra-se cadastrado!");
                }
            }

            _logger.LogInformation($"Cliente sendo atualizada. Segue objeto a ser atualizado: {cliente}");
            await _clienteService.Update(cliente);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(
            int id,
            [FromServices] IClienteService _clienteService)
        {
            var cliente = await _clienteService.GetById(id);

            if (cliente == null)
            {
                _logger.LogWarning($"Cliente de id:{id} não foi encontrado para ser excluido!");
                return NotFound($"Cliente de id:{id} não foi encontrado!");
            }

            await _clienteService.Delete(id);

            return Ok(cliente);
        }
    }
}
