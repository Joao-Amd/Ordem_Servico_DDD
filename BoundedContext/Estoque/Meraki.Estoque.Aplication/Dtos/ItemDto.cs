namespace Meraki.Estoque.Aplication.Dtos
{
    public class ItemDto
    {
        public int Identificacao { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public Guid IdUnidade { get; set; }
        public bool Ativo { get; set; }
    }
}
