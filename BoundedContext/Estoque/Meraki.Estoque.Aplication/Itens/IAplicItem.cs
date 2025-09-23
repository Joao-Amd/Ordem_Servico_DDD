using Meraki.Estoque.Aplication.Itens.Dtos;

namespace Meraki.Estoque.Aplication.Itens
{
    public interface IAplicItem
    {
        Task Inserir(ItemDto itemDto);
        Task Atualizar(Guid idItem, ItemDto itemDto);
        Task AtivarInativar(Guid iditem);
    }
}
