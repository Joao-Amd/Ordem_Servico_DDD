using Meraki.Cadastros.Data.Patterns;
using Meraki.Core.Interfaces;
using Meraki.Estoque.Data;

namespace Meraki.Cadastros.Data.Base
{
    public class RepBaseEstoque<T> : RepBase<T, ContextEstoque>, IRepBaseEstoque<T> 
        where T : class
    {
        public RepBaseEstoque(ContextEstoque contexto) : base(contexto){}
    }
}
