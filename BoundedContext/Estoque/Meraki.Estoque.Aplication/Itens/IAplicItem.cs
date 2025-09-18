using Meraki.Estoque.Aplication.Itens.Dtos;

namespace Meraki.Estoque.Aplication.Itens
{
    public interface IAplicItem
    {
        public Task Inserir(ItemDto itemDto);
        public Task Atualizar(Guid idItem, ItemDto itemDto);
    }
}
