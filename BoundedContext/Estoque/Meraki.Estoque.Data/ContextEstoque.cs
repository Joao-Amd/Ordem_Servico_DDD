using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Meraki.Estoque.Data
{
    public class ContextEstoque : DbContext
    {
        public ContextEstoque(DbContextOptions<ContextEstoque> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
