using Meraki.Core.Interfaces;
using Meraki.Core.Patterns.Repositorys;

namespace Meraki.Cadastros.Data.Base
{
    public interface IRepBaseEstoque<T> : IRepBase<T, ContextCadastros> where T : IAggregateRoot
    {
    }
}
