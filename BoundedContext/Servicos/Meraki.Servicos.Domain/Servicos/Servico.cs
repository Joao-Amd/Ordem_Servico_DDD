using Meraki.Core.Base;

namespace Meraki.Servicos.Domain.Servicos
{
    public class Servico : Identificador
    {
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }

        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }
    }
}
