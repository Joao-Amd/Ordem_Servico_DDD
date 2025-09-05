using Meraki.Estoque.Domain.Unidades;

namespace Meraki.Estoque.Domain.Itens
{
    public class Item
    {
        public Guid Id { get; set; }
        public int Identificacao { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public Guid IdUnidade { get; set; }
        public bool Ativo { get; set; }
        public virtual Unidadade Unidade { get; set; }

        public static Item Criar(
            int identificacao, 
            string descricao, 
            decimal preco, 
            Guid idUnidade)
        {
            return new Item
            {
                Id = Guid.NewGuid(),
                Identificacao = identificacao,
                Descricao = descricao,
                Preco = preco,
                IdUnidade = idUnidade,
                Ativo = true
            };
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
