using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Meraki.Cadastros.Data
{
    public class ContextCadastros : DbContext
    {
        public ContextCadastros(DbContextOptions<ContextCadastros> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
