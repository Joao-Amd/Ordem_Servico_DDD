using Meraki.Cadastros.Domain.Clientes;
using Meraki.Cadastros.Domain.Value_Objects;

namespace Meraki.Cadastros.Aplication.Clientes.ViewModels
{
    public class ClienteEnderecoViewModel
    {
        public string Logradouro { get; private set; } = string.Empty;
        public string? Numero { get; private set; }
        public string? Complemento { get; private set; }
        public string Bairro { get; private set; } = string.Empty;
        public string Cidade { get; private set; } = string.Empty;
        public string Uf { get; private set; } = string.Empty;
        public string Cep { get; private set; }

        public static ClienteEnderecoViewModel Criar(ClienteEndereco clienteEndereco)
        {
            return new ClienteEnderecoViewModel
            {
                Logradouro = clienteEndereco.Logradouro,
                Numero = clienteEndereco.Numero,
                Complemento = clienteEndereco.Complemento,
                Bairro = clienteEndereco.Bairro,
                Cidade = clienteEndereco.Cidade,
                Uf = clienteEndereco.Uf,
                Cep = clienteEndereco.Cep.Numero
            };
        }
    }
}
