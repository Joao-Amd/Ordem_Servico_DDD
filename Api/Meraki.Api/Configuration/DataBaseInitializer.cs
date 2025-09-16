using Meraki.Cadastros.Data;
using Meraki.Estoque.Data;
using Meraki.Estoque.Data.Seedings;
using Microsoft.EntityFrameworkCore;

namespace Meraki.Api.Configuration
{
    public class DataBaseInitializer
    {
        private readonly IUnidadesSeedings _unidadesSeedings;
        private readonly ContextCadastros _cadastrosContext;
        private readonly ContextEstoque _estoqueContext;

        public DataBaseInitializer(
            IUnidadesSeedings unidadesSeedings,
            ContextCadastros cadastrosContext,
            ContextEstoque estoqueContext)
        {
            _unidadesSeedings = unidadesSeedings;
            _cadastrosContext = cadastrosContext;
            _estoqueContext = estoqueContext;
        }

        public void Initialize()
        {
            _cadastrosContext.Database.Migrate();
            _estoqueContext.Database.Migrate();

            _unidadesSeedings.Seed();
        }
    }
}
