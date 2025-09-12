using Meraki.Core.Interfaces;
using Meraki.Estoque.Domain.Unidades;

namespace Meraki.Estoque.Domain.Itens
{
    public class Item 
    {
        public Item(){}
        public Item(
            int identificacao,
            string descricao,
            decimal preco,
            Unidade unidade)
        {
            Id = Guid.NewGuid();
            Identificacao = identificacao;
            Descricao = descricao;
            Preco = preco;
            IdUnidade = unidade.Id;
            Unidade = unidade;
            Ativo = true;
        }

        public Guid Id { get; set; }
        public int Identificacao { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public Guid IdUnidade { get; set; }
        public bool Ativo { get; set; }
        public virtual Unidade Unidade { get; set; }

        public static Item Criar(
            int identificacao,
            string descricao,
            decimal preco,
            Unidade unidade)
        {
            return new Item(identificacao, descricao, preco, unidade);
        }

        public void Atualizar(
            string descricao,
            decimal preco,
            Guid idUnidade,
            bool ativo)
        {
            Descricao = descricao;
            Preco = preco;
            IdUnidade = idUnidade;
            Ativo = ativo;
        }
    }
}
