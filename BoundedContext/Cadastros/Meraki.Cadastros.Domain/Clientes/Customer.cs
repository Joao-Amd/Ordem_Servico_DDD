using Meraki.Cadastros.Domain.Clientes.Enumeradores;
using Meraki.Cadastros.Domain.Value_Objects;
using Meraki.Core.Interfaces;

namespace Meraki.Cadastros.Domain.Clientes
{
    public class Customer : IAggregateRoot
    {
        protected Customer(string nome,
                          EnumTipoPessoa tipoPessoa,
                          string? cpf,
                          CustomerAddress endereco,
                          CustomerContact contato)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            TipoPessoa = tipoPessoa;
            Cpf = string.IsNullOrEmpty(cpf) ? null : new Cpf(cpf);
            Address = endereco;
            Contact = contato;
        }

        public Guid Id { get; }
        public string Nome { get; private set; } = string.Empty;
        public EnumTipoPessoa TipoPessoa { get; private set; }
        public Cpf? Cpf { get; private set; }

        public virtual CustomerCorporate? CorporateData { get; private set; }
        public virtual CustomerAddress Address { get; private set; }
        public virtual CustomerContact Contact { get; private set; }

        public static Customer Criar(
            string nome,
            EnumTipoPessoa tipoPessoa,
            string? cpf,
            string? corporateName,
            string? tradeName,
            string cnpj,
            string? stateRegistration,
            string? municipalRegistration,
            CustomerAddress endereco,
            CustomerContact contato)
        {          
            var cliente = new Customer(
                nome,
                tipoPessoa,
                cpf,
                endereco,
                contato);

            if (tipoPessoa == EnumTipoPessoa.Juridica)
            {
                cliente.SetCorporationDate(
                    corporateName,
                    tradeName,
                    cnpj,
                    stateRegistration,
                    municipalRegistration);
            }

            return cliente;
        }

        public void Alter(
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

            Address.AlterarEndereco(logradouro,
                         numero,
                         complemento,
                         bairro,
                         cidade,
                         uf,
                         cep);

            Contact.AlterarContato(telefone, celular, email);
        }

        public void SetCorporationDate(
            string? corporateName,
            string? tradeName,
            string cnpj,
            string? stateRegistration,
            string? municipalRegistration)
        {
            if (CorporateData != null) return;

            CorporateData = CustomerCorporate.Criar(
            corporateName,
            tradeName,
            cnpj,
            stateRegistration,
            municipalRegistration);
        }

        public void AlterCorporationDate(
            string? corporateName,
            string? tradeName,
            string cnpj,
            string? stateRegistration,
            string? municipalRegistration)
        {
            CorporateData?.Alter(
                corporateName,
                tradeName,
                cnpj,
                stateRegistration,
                municipalRegistration);
        }
    }
}
