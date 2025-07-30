using Meraki.Cadastros.Domain.Clientes.Enumeradores;
using Meraki.Cadastros.Domain.Value_Objects;
using Meraki.Core.Interfaces;

namespace Meraki.Cadastros.Domain.Clientes
{
    public class Cliente : IAggregateRoot
    {
        protected Cliente(string nome,
                          EnumTipoPessoa tipoPessoa,
                          string? cpf,
                          ClienteEndereco endereco,
                          ClienteContato contato)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            TipoPessoa = tipoPessoa;
            Cpf = string.IsNullOrEmpty(cpf) ? null : new Cpf(cpf);
            Endereco = endereco;
            Contato = contato;
        }

        public Guid Id { get; }
        public string Nome { get; private set; } = string.Empty;
        public EnumTipoPessoa TipoPessoa { get; private set; }
        public Cpf? Cpf { get; private set; }

        public virtual ClienteDadosCorporativo? DadosCorporativo { get; private set; }
        public virtual ClienteEndereco Endereco { get; private set; }
        public virtual ClienteContato Contato { get; private set; }

        public static Cliente Criar(
            string nome,
            EnumTipoPessoa tipoPessoa,
            string? cpf,
            string? razaoSocial,
            string? nomeFantasia,
            string cnpj,
            string? inscricaoEstadual,
            string? inscricaoMunicipal,
            ClienteEndereco endereco,
            ClienteContato contato)
        {          
            var cliente = new Cliente(
                nome,
                tipoPessoa,
                cpf,
                endereco,
                contato);

            if (tipoPessoa == EnumTipoPessoa.Juridica)
            {
                cliente.AdicionarDadosCorporativos(
                    razaoSocial,
                    nomeFantasia,
                    cnpj,
                    inscricaoEstadual,
                    inscricaoMunicipal);
            }

            return cliente;
        }

        public void AlterarDados(
            string nome,
            EnumTipoPessoa tipoPessoa,
            string? cpf,
            string? telefone,
            string celular,
            string email,
            string logradouro,
            string? numero,
            string? complemento,
            string bairro,
            string cidade,
            string uf,
            string cep)
        {
            Nome = nome;
            TipoPessoa = tipoPessoa;
            Cpf = string.IsNullOrEmpty(cpf) ? null : new Cpf(cpf);

            Endereco.AlterarEndereco(logradouro,
                         numero,
                         complemento,
                         bairro,
                         cidade,
                         uf,
                         cep);

            Contato.AlterarContato(telefone, celular, email);
        }

        public void AdicionarDadosCorporativos(
            string? razaoSocial,
            string? nomeFantasia,
            string cnpj,
            string? inscricaoEstadual,
            string? inscricaoMunicipal)
        {
            if (DadosCorporativo != null) return;

            DadosCorporativo = ClienteDadosCorporativo.Criar(
            razaoSocial,
            nomeFantasia,
            cnpj,
            inscricaoEstadual,
            inscricaoMunicipal);
        }

        public void AlterarDadosCorporativos(
            string? razaoSocial,
            string? nomeFantasia,
            string cnpj,
            string? inscricaoEstadual,
            string? inscricaoMunicipal)
        {
            DadosCorporativo?.AlterarDados(
                razaoSocial,
                nomeFantasia,
                cnpj,
                inscricaoEstadual,
                inscricaoMunicipal);
        }
    }
}
