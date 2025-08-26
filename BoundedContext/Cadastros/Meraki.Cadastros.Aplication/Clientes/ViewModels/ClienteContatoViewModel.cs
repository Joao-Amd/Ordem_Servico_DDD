using Meraki.Cadastros.Domain.Clientes;

namespace Meraki.Cadastros.Aplication.Clientes.ViewModels
{
    public class ClienteContatoViewModel
    {
        public string Telefone { get; private set; }
        public string Celular { get; private set; }
        public string Email { get; private set; }

        public static ClienteContatoViewModel Criar(ClienteContato clienteContato)
        {
            return new ClienteContatoViewModel
            {
                Telefone = clienteContato.Telefone.Numero,
                Celular = clienteContato.Celular.Numero,
                Email = clienteContato.Email.Endereco
            };
        }
    }
}
