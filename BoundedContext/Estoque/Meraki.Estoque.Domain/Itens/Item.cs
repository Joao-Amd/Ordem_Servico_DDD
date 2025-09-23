using Meraki.Core.Base;
using Meraki.Core.Interfaces;
using Meraki.Estoque.Domain.Unidades;

namespace Meraki.Estoque.Domain.Itens
{
    public class Item : Identificador
    {
        public Item()
        {
            Id = Guid.NewGuid();
            Ativo = true;
        }
        public Item(string descricao, decimal preco, Unidade unidade) : this()
        {
            Descricao = descricao;
            Preco = preco;
            IdUnidade = unidade.Id;
            Unidade = unidade;
        }

        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public Guid IdUnidade { get; set; }
        public bool Ativo { get; set; }
        public virtual Unidade Unidade { get; set; }

        public static Item Criar(string descricao, decimal preco, Unidade unidade)
        {
            return new Item(descricao, preco, unidade);
        }

        public void Atualizar(
            string descricao,
            decimal preco,
            Guid idUnidade)
        {
            Descricao = descricao;
            Preco = preco;
            IdUnidade = idUnidade;
        }

        public void AtivarInativar()
        {
            Ativo = !Ativo;
        }
    }
}
