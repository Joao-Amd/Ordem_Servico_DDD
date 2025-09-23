using Meraki.Cadastros.Domain.Clientes.Enumeradores;
using Meraki.Cadastros.Domain.Value_Objects;
using Meraki.Core.Base;
using Meraki.Core.Interfaces;

namespace Meraki.Cadastros.Domain.Clientes
{
    public class Cliente : Identificador, IAggregateRoot
    {
        public Cliente(){ }
        protected Cliente(string nome,
                          EnumTipoPessoa tipoPessoa,
                          string cpf)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            TipoPessoa = tipoPessoa;
            Cpf = string.IsNullOrEmpty(cpf) ? null : new Cpf(cpf);
        }

        public Guid Id { get; }
        public string Nome { get; private set; } = string.Empty;
        public EnumTipoPessoa TipoPessoa { get; private set; }
        public Cpf Cpf { get; private set; }
        public virtual DadosCorporativo DadosCorporativo { get; private set; }
        public virtual ClienteEndereco Endereco { get; private set; }
        public virtual ClienteContato Contato { get; private set; }

        public static Cliente Criar(
            string nome,
            EnumTipoPessoa tipoPessoa,
            string cpf,
            string corporateName,
            string tradeName,
            string cnpj,
            string stateRegistration,
            string municipalRegistration)
        {          
            var cliente = new Cliente(
                nome,
                tipoPessoa,
                cpf);

            if (tipoPessoa == EnumTipoPessoa.Juridica)
            {
                cliente.InserirDadosCorporativo(
                    corporateName,
                    tradeName,
                    cnpj,
                    stateRegistration,
                    municipalRegistration);
            }

            return cliente;
        }

        public void AtribuirContato(string telefone, string celular, string email)
        {
            var contato = ClienteContato.Criar(this, telefone, celular, email);
            Contato = contato;
        }

        public void AtribuirEndereco(
            string logradouro,
            string numero,
            string complemento,
            string bairro,
            string cidade,
            string uf,
            string cep)
        {
            var endereco = ClienteEndereco.Criar(
                this,
                logradouro,
                numero,
                complemento,
                bairro,
                cidade,
                uf,
                cep);

            Endereco = endereco;
        }

        public void Atualizar(
            string nome,
            EnumTipoPessoa tipoPessoa,
            string cpf,
            string telefone,
            string celular,
            string email,
            string logradouro,
            string numero,
            string complemento,
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

        public void InserirDadosCorporativo(
            string razaoSocial,
            string nomeFantasia,
            string cnpj,
            string inscricaoEstadual,
            string inscricaoMunicipal)
        {
            if (DadosCorporativo != null) return;

            DadosCorporativo = DadosCorporativo.Criar(
                this,
                razaoSocial,
                nomeFantasia,
                cnpj,
                inscricaoEstadual,
                inscricaoMunicipal);
        }

        public void AlterarDadosCorporativo(
            string razaoSocial,
            string nomeFantasia,
            string cnpj,
            string inscricaoEstadual,
            string inscricaoMunicipal)
        {
            DadosCorporativo?.Atualizar(
                razaoSocial,
                nomeFantasia,
                cnpj,
                inscricaoEstadual,
                inscricaoMunicipal);
        }
    }
}
