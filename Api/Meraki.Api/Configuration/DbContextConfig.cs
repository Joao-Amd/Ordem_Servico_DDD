using Meraki.Cadastros.Data;
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
        }
    }
}
