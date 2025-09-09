using Meraki.Cadastros.Data;
using Meraki.Estoque.Data;
using Microsoft.EntityFrameworkCore;

namespace Meraki.Api.Configuration
{
    public static class DbContextConfig
    {
        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextCadastros>(options =>
                options.UseLazyLoadingProxies().
                UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ContextEstoque>(options =>
                options.UseLazyLoadingProxies().
                UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
