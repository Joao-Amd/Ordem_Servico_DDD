using Microsoft.EntityFrameworkCore;

namespace Meraki.Cadastros.Data
{
    public class ContextCadastros : DbContext
    {
        public ContextCadastros(DbContextOptions<ContextCadastros> options) : base(options) { }
    }
}
