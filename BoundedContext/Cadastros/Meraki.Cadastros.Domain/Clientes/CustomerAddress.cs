using Meraki.Cadastros.Domain.Value_Objects;

namespace Meraki.Cadastros.Domain.Clientes
{
    public class CustomerAddress
    {
        public CustomerAddress(
            string logradouro,
            string? numero,
            string? complemento,
            string bairro,
            string cidade,
            string uf,
            string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Cep = new Cep(cep);
            _validar();
        }

        public string Logradouro { get; private set; } = string.Empty;
        public string? Numero { get; private set; }
        public string? Complemento { get; private set; }
        public string Bairro { get; private set; } = string.Empty;
        public string Cidade { get; private set; } = string.Empty;
        public string Uf { get; private set; } = string.Empty;
        public Cep Cep { get; private set; } 

        public virtual Customer Cliente { get; }

        public static CustomerAddress Criar(
            string logradouro,
            string? numero,
            string? complemento,
            string bairro,
            string cidade,
            string uf,
            string cep)
        {
            return new CustomerAddress(
                logradouro,
                numero,
                complemento,
                bairro,
                cidade,
                uf,
                cep);
        }

        public void AlterarEndereco(
            string logradouro,
            string? numero,
            string? complemento,
            string bairro,
            string cidade,
            string uf,
            string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Cep = new Cep(cep);
            _validar();
        }

        public void _validar()
        {
            if (string.IsNullOrWhiteSpace(Logradouro)) throw new ArgumentException("Logradouro é obrigatório.");
            if (string.IsNullOrWhiteSpace(Bairro)) throw new ArgumentException("Bairro é obrigatório.");
            if (string.IsNullOrWhiteSpace(Cidade)) throw new ArgumentException("Cidade é obrigatória.");
            if (string.IsNullOrWhiteSpace(Uf) || Uf.Length != 2) throw new ArgumentException("UF inválido.");
        }
    }
}
