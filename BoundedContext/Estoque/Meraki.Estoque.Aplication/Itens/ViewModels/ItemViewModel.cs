namespace Meraki.Estoque.Aplication.Itens.ViewModels
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }
        public int Identificacao { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public Guid IdUnidade { get; set; }
        public bool Ativo { get; set; }
    }
}
