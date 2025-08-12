using Meraki.Itens.Domain.Itens.Enums;

namespace Meraki.Itens.Domain.Itens
{
    public class Item
    {
        public Item(string descricao, string observacao, EnumTipoItem tipo)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Observacao = observacao;
            Tipo = tipo;
        }

        public Guid Id { get; set; }

        public string Descricao { get; private set; }
        public string Observacao { get; private set; }
        public EnumTipoItem Tipo { get; private set; }

        public static Item Criar(string descricao, string observacao, EnumTipoItem tipo) 
        { 
            return new Item(descricao, observacao, tipo);
        }

        public void Atualizar(string descricao, string observacao, EnumTipoItem tipo)
        {
            Descricao = descricao;
            Observacao = observacao;
            Tipo = tipo;
        }
    }
}
