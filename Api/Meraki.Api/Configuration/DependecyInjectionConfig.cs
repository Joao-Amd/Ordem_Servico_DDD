using Meraki.Cadastros.Data.Base;
using Meraki.Cadastros.Data.Patterns;
using Meraki.Core.Patterns.Repositorys;
using System.Reflection;

namespace Meraki.Api.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.Scan(scan =>
                scan.FromAssemblies(
                    Assembly.Load("Meraki.Agenda.Aplication"),
                    Assembly.Load("Meraki.Agenda.Data"),
                    Assembly.Load("Meraki.Agenda.Domain"),
                    Assembly.Load("Meraki.Cadastros.Aplication"),
                    Assembly.Load("Meraki.Cadastros.Data"),
                    Assembly.Load("Meraki.Cadastros.Domain"),
                    Assembly.Load("Meraki.Core"),
                    Assembly.Load("Meraki.Estoque.Aplication"),
                    Assembly.Load("Meraki.Estoque.Data"),
                    Assembly.Load("Meraki.Estoque.Domain"),
                    Assembly.Load("Meraki.Orcamento.Aplication"),
                    Assembly.Load("Meraki.Orcamento.Data"),
                    Assembly.Load("Meraki.Orcamento.Domain"),
                    Assembly.Load("Meraki.OrdemServico.Aplication"),
                    Assembly.Load("Meraki.OrdemServico.Data"),
                    Assembly.Load("Meraki.OrdemServico.Domain"),
                    Assembly.Load("Meraki.Servicos.Aplication"),
                    Assembly.Load("Meraki.Servicos.Data"),
                    Assembly.Load("Meraki.Servicos.Domain"),
                    Assembly.Load("Meraki.Vendas.Aplication"),
                    Assembly.Load("Meraki.Vendas.Data"),
                    Assembly.Load("Meraki.Vendas.Domain"))
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddScoped(typeof(IRepBaseCadastros<>), typeof(RepBaseCadastros<>));

            return services;
        }
    }
}
