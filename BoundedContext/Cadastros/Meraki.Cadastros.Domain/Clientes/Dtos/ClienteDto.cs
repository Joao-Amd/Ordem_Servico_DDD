using Meraki.Cadastros.Domain.Clientes.Enumeradores;

namespace Meraki.Cadastros.Domain.Clientes.Dtos
{
    public class ClienteDto
    {
        public string Nome { get; set; } = string.Empty;
        public EnumTipoPessoa TipoPessoa { get; set; }
        public string Logradouro { get; set; } = string.Empty;
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string? Telefone { get; set; } 
        public string Celular { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? RazaoSocial { get; set; } 
        public string? NomeFantasia { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string? InscricaoEstadual { get; set; }
        public string? InscricaoMunicipal { get; set; }
    }
}
