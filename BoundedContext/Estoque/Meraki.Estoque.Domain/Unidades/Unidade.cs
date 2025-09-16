namespace Meraki.Estoque.Domain.Unidades
{
    public class Unidade
    {
        public Unidade(
            string sigla,
            decimal fator,
            string descricao)
        {
            Id = Guid.NewGuid();
            Sigla = sigla;
            Descricao = descricao;
            Fator = fator;
        }

        public Guid Id { get; }
        public string Sigla { get; }
        public string Descricao { get; }
        public decimal Fator { get; }
    }
}
