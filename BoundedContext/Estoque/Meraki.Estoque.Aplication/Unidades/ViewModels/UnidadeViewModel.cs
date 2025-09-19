using Meraki.Estoque.Domain.Unidades;

namespace Meraki.Estoque.Aplication.Unidades.ViewModels
{
    public class UnidadeViewModel
    {
        public Guid Id { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public decimal Fator { get; set; }

        public static UnidadeViewModel Criar(Unidade unidade)
        {
            return new UnidadeViewModel
            {
                Id = unidade.Id,
                Sigla = unidade.Sigla,
                Descricao = unidade.Descricao,
                Fator = unidade.Fator
            };
        }
    }
}
