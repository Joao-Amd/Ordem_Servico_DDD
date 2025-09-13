using Meraki.Core.Patterns.UnitOfWorks;

namespace Meraki.Cadastros.Data.Patterns
{
    public class UnitOfWorkCadastros : UnitOfWork<ContextCadastros>, IUnitOfWorkCadastros
    {
        public UnitOfWorkCadastros(ContextCadastros contexto) : base(contexto)
        {
        }
    }
}
