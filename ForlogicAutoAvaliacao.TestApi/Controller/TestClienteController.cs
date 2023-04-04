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
    public class TestClienteController
    {
        private readonly ClientesController _clienteController;
        private readonly Mock<IClienteService> clienteService;

        public TestClienteController()
        {
            clienteService = new Mock<IClienteService>();
            var mock = new Mock<ILogger<AvaliacoesController>>();
            ILogger<AvaliacoesController> logger = mock.Object;
            logger = Mock.Of<ILogger<AvaliacoesController>>();

            _clienteController = new ClientesController(logger);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturn200Status()
        {
            /// Arrange
            clienteService.Setup(_ => _.GetAll()).ReturnsAsync(ClienteMockData.GetClientesData());

            /// Act
            var result = await _clienteController.GetClientes(clienteService.Object);

            /// Assert
            Assert.IsType<OkObjectResult>(result);

            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturn204NoContentStatus()
        {
            /// Arrange
            clienteService.Setup(_ => _.GetAll()).ReturnsAsync(ClienteMockData.GetEmptyClientes());

            /// Act
            var result = (NoContentResult)await _clienteController.GetClientes(clienteService.Object);

            /// Assert
            result.StatusCode.Should().Be(204);
            clienteService.Verify(_ => _.GetAll(), Times.Exactly(1));
        }

        [Fact]
        public async Task SaveAsync_ShouldCall_ITodoService_SaveAsync_AtleastOnce()
        {
            /// Arrange
            var newCliente = ClienteMockData.NewCliente();

            /// Act
            var result = await _clienteController.PostCliente(newCliente, clienteService.Object);

            /// Assert
            clienteService.Verify(_ => _.Insert(newCliente), Times.Exactly(1));
        }

        [Fact]
        public async Task CheckCNPJExist()
        {
            /// Arrange
            var clientes = ClienteMockData.GetClientesData();
            clienteService.Setup(_ => _.GetAll()).ReturnsAsync(clientes);

            /// Act
            var result = await _clienteController.GetClientes(clienteService.Object);           
            var cnpj = clientes[0].Cnpj;

            /// Assert
            Assert.Equal("15315453000184", cnpj);
        }
    }
}
