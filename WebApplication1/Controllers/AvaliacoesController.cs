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
    public class AvaliacoesController : ControllerBase
    {
        protected readonly ILogger<AvaliacoesController> _logger;

        public AvaliacoesController(ILogger<AvaliacoesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAvaliacoes(
            [FromServices] IAvaliacaoService _avaliacaoService)
        {
            var avaliacoes = await _avaliacaoService.GetAll();
            if (avaliacoes.Count() == 0)
            {
                _logger.LogInformation("Não existe avaliações cadastradas!");
                return NoContent();
            }

            return Ok(avaliacoes.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAvaliacao(
            int id,
            [FromServices] IAvaliacaoService _avaliacaoService)
        {
            var avaliacao = await _avaliacaoService.GetById(id);
            if (avaliacao == null)
            {
                _logger.LogWarning($"Avaliação não encontrado para o id:{id} informado!");
                return NotFound($"Avaliação não encontrado para o id:{id} informado!");
            }

            return Ok(avaliacao);
        }

        [HttpPost]
        public async Task<IActionResult> PostAvaliacao(
            [FromBody] Avaliacao avaliacao,
            [FromServices] IAvaliacaoService _avaliacaoService)
        {
            if (_avaliacaoService.ExistAvaliacoesToMesAno(avaliacao.IdCliente, avaliacao.MesAno))
            {
                _logger.LogInformation("Já existe avaliação cadastrada para esse cliente!");
                return NotFound("Já existe avaliação cadastrada para esse cliente!");
            }

            _logger.LogInformation($"Avaliação sendo inserida. Segue dados a serem inseridos: {avaliacao}");
            await _avaliacaoService.Insert(avaliacao);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAvaliacao(
            Avaliacao avaliacao,
            [FromServices] IAvaliacaoService _avaliacaoService)
        {
            _logger.LogInformation($"Avaliação sendo atualizada. Segue objeto a ser atualizado: {avaliacao}");
            await _avaliacaoService.Update(avaliacao);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvaliacao(
            int id,
            [FromServices] IAvaliacaoService _avaliacaoService)
        {
            var avaliacao = await _avaliacaoService.GetById(id);

            if (avaliacao == null)
            {
                _logger.LogWarning($"Avaliação de id:{id} não foi encontrado para ser excluido!");
                return NotFound($"Avaliação de id:{id} não foi encontrado!");
            }

            await _avaliacaoService.Delete(id);

            return Ok(avaliacao);
        }
    }
}
