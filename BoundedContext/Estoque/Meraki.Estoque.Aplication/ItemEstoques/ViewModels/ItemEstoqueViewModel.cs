using Meraki.Estoque.Aplication.Itens.ViewModels;
using Meraki.Estoque.Domain.Estoques;

namespace Meraki.Estoque.Aplication.Estoques.ViewModels
{
    public class ItemEstoqueViewModel
    {
        public Guid Id { get; set; }
        public Guid IdItem { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public virtual ItemViewModel Item { get; set; }

        public static ItemEstoqueViewModel Criar(ItemEstoque itemEstoque)
        {
            return new ItemEstoqueViewModel
            {
                Id = itemEstoque.Id,
                IdItem = itemEstoque.IdItem,
                Saldo = itemEstoque.Saldo,
                DataAtualizacao = itemEstoque.DataAtualizacao,
                Item = ItemViewModel.Criar(itemEstoque.Item)
            };
        }
    }
}
