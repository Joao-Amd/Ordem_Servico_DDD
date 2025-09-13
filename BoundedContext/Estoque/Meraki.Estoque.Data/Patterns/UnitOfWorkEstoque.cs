using Meraki.Core.Patterns.UnitOfWorks;
using Meraki.Estoque.Data;

namespace Meraki.Cadastros.Data.Patterns
{
    public class UnitOfWorkEstoque : UnitOfWork<ContextEstoque>, IUnitOfWorkEstoque
    {
        public UnitOfWorkEstoque(ContextEstoque contexto) : base(contexto)
        {
        }
    }
}
