using FluentAssertions;
using ForlogicAutoAvaliacao.Controllers;
using ForlogicAutoAvaliacao.Domain.Interfaces.Services;
using ForlogicAutoAvaliacao.TestApi.MockData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ForlogicAutoAvaliacao.TestApi.Controller
{
    public class TestAvaliacaoController
    {
        private readonly AvaliacoesController _avaliacoesController;
        private readonly Mock<IAvaliacaoService> avaliacaoService;
       

        public TestAvaliacaoController()
        {
            avaliacaoService = new Mock<IAvaliacaoService>();

            var mock = new Mock<ILogger<AvaliacoesController>>();
            ILogger<AvaliacoesController> logger = mock.Object;
            logger = Mock.Of<ILogger<AvaliacoesController>>();

            _avaliacoesController = new AvaliacoesController(logger);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturn200Status()
        {
            /// Arrange
            avaliacaoService.Setup(_ => _.GetAll()).ReturnsAsync(AvaliacaoMockData.GetAvaliacoesData());

            /// Act
            var result = await _avaliacoesController.GetAvaliacoes(avaliacaoService.Object);

            /// Assert
            Assert.IsType<OkObjectResult>(result);

            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturn204NoContentStatus()
        {
            /// Arrange
            avaliacaoService.Setup(_ => _.GetAll()).ReturnsAsync(AvaliacaoMockData.GetEmptyAvaliacoes());

            /// Act
            var result = (NoContentResult)await _avaliacoesController.GetAvaliacoes(avaliacaoService.Object);

            /// Assert
            result.StatusCode.Should().Be(204);
            avaliacaoService.Verify(_ => _.GetAll(), Times.Exactly(1));
        }

        [Fact]
        public async Task SaveAsync_ShouldCall_ITodoService_SaveAsync_AtleastOnce()
        {
            /// Arrange
            var newAvaliacao = AvaliacaoMockData.NewAvaliacao();

            /// Act
            var result = await _avaliacoesController.PostAvaliacao(newAvaliacao, avaliacaoService.Object);

            /// Assert
            avaliacaoService.Verify(_ => _.Insert(newAvaliacao), Times.Exactly(1));
        }
    }
}
