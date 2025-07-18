using Meraki.Cadastros.Domain.Clientes.Enumeradores;

namespace Meraki.Cadastros.Domain.Clientes
{
    public class Cliente
    {
        protected Cliente(string nome,
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
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public string Nome { get; private set; } = string.Empty;
        public EnumTipoPessoa TipoPessoa { get; private set; }
        public string? Cpf { get; private set; }
        public string? Telefone { get; private set; }
        public string Celular { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Logradouro { get; private set; } = string.Empty;
        public string? Numero { get; private set; } = string.Empty;
        public string? Complemento { get; private set; }
        public string Bairro { get; private set; } = string.Empty;
        public string Cidade { get; private set; } = string.Empty;
        public string Uf { get; private set; } = string.Empty;
        public string Cep { get; private set; } = string.Empty;

        public virtual DadosCorporativo? DadosCorporativo { get; private set; }

        public static Cliente Criar(
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
            return new Cliente(
                nome,
                tipoPessoa,
                cpf,
                telefone,
                celular,
                email,
                logradouro,
                numero,
                complemento,
                bairro,
                cidade,
                uf,
                cep);
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
            Cpf = cpf;
            Telefone = telefone;
            Celular = celular;
            Email = email;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Cep = cep;
        }

        public void AdicionarDadosCorporativos(
            string? razaoSocial,
            string? nomeFantasia,
            string cnpj,
            string? inscricaoEstadual,
            string? inscricaoMunicipal)
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
