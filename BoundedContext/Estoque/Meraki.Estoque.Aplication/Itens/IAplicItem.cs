using Meraki.Estoque.Aplication.Dtos;
using Meraki.Estoque.Aplication.Itens.ViewModels;

namespace Meraki.Estoque.Aplication.Itens
{
    public interface IAplicItem
    {
        public List<ItemViewModel> Listar();

        public ItemViewModel ObterPorId(Guid id);
        public void Inserir(ItemDto itemDto);
        public void Atualizar(ItemDto itemDto);
    }
}
