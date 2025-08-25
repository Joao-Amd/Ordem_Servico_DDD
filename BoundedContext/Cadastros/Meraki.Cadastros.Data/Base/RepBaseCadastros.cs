using Meraki.Cadastros.Data.Patterns;
using Meraki.Core.Interfaces;

namespace Meraki.Cadastros.Data.Base
{
    public class RepBaseCadastros<T> : RepBase<T, ContextCadastros>, IRepBaseCadastros<T> 
        where T : class, IAggregateRoot
    {
        public RepBaseCadastros(ContextCadastros contexto) : base(contexto){}
    }
}
