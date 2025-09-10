using Meraki.Core.Interfaces;
using Meraki.Core.Patterns.Repositorys;
using Meraki.Estoque.Data;

namespace Meraki.Cadastros.Data.Base
{
    public interface IRepBaseEstoque<T> : IRepBase<T, ContextEstoque> where T : class 
    {
    }
}
