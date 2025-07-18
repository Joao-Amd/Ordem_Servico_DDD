using Microsoft.EntityFrameworkCore;

namespace Meraki.Cadastros.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}
