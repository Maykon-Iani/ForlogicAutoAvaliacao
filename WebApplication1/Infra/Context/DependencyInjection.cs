using ForlogicAutoAvaliacao.Domain.Interfaces.Repository;
using ForlogicAutoAvaliacao.Domain.Interfaces.Services;
using ForlogicAutoAvaliacao.Infra.Repository;
using ForlogicAutoAvaliacao.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ForlogicAutoAvaliacao.Infra.Context
{
    public static class DependencyInjection
    {
        public static void ConfigureDependencyInjection(IServiceCollection services)
        {
            AddClienteDependencies(services);
            AddAvaliacaoDependencies(services);
        }

        private static void AddClienteDependencies(IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }

        private static void AddAvaliacaoDependencies(IServiceCollection services)
        {
            services.AddScoped<IAvaliacaoService, AvaliacaoService>();
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
        }
    }
}
