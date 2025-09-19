using Meraki.Estoque.Aplication.Estoques.Dtos;

namespace Meraki.Estoque.Aplication.Estoques
{
    public interface IAplicItemEstoque
    {
        Task Inserir(ItemEstoqueDto itemEstoqueDto);
        Task Atualizar(Guid idItemEstoque, ItemEstoqueDto itemEstoqueDto);
    }
}
