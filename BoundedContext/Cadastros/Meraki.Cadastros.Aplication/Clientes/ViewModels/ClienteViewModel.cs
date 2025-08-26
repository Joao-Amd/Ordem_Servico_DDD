using Meraki.Cadastros.Domain.Clientes;
using Meraki.Cadastros.Domain.Clientes.Enumeradores;

namespace Meraki.Cadastros.Aplication.Clientes.ViewModels
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public EnumTipoPessoa TipoPessoa { get; set; }
        public string? Cpf { get; set; }
        public virtual DadosCorporativosViewModel DadosCorporativo { get; set; }
        public virtual ClienteEnderecoViewModel Endereco { get; set; }
        public virtual ClienteContatoViewModel Contato { get; set; }

        public static ClienteViewModel Criar(Cliente cliente)
        {
            return new ClienteViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                TipoPessoa = cliente.TipoPessoa,
                Cpf = cliente.Cpf?.Numero,
                DadosCorporativo = cliente.TipoPessoa == EnumTipoPessoa.Juridica && cliente.DadosCorporativo != null ?
                    DadosCorporativosViewModel.Criar(cliente.DadosCorporativo) : null,

                Endereco = ClienteEnderecoViewModel.Criar(cliente.Endereco),
                Contato = ClienteContatoViewModel.Criar(cliente.Contato),
            };
        }
    }
}
