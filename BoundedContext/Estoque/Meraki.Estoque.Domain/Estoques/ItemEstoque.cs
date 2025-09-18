using Meraki.Estoque.Domain.Itens;

namespace Meraki.Estoque.Domain.Estoques
{
    public class ItemEstoque
    {
        public ItemEstoque(){}
        public ItemEstoque(Item item) 
        {
            Id = Guid.NewGuid();
            Item = item;
        }

        public Guid Id { get; }
        public Guid IdItem { get; }
        public decimal Saldo { get; private set; }
        public DateTime DataAtualizacao { get; set; }
        public virtual Item Item { get; set; }

        public static ItemEstoque Criar(Item item)
        {
            return new ItemEstoque(item);
        }

        public void AtualizarSaldo(decimal quantidade)
        {
            Saldo = quantidade;
            DataAtualizacao = DateTime.Now;
        }
    }
}
