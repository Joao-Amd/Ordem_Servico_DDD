namespace Meraki.Cadastros.Domain.Value_Objects
{
    public class Cpf
    {
        public Cpf(string numero)
        {
            _validar(numero);
            Numero = numero;
        }

        public string Numero { get; }

        private void _validar(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("CPF não pode ser nulo ou vazio.");

            numero = _removerCaracteresNaoNumericos(numero);

            if (numero.Length != 11)
                throw new ArgumentException("CPF deve conter 11 dígitos.");

            if (!_cpfValido(numero))
                throw new ArgumentException("CPF inválido.");
        }

        private string _removerCaracteresNaoNumericos(string valor) =>
             new string(valor.Where(char.IsDigit).ToArray());

        private bool _cpfValido(string cpf)
        {
            var repetidos = new[]
            {
                "00000000000","11111111111","22222222222","33333333333","44444444444",
                "55555555555","66666666666","77777777777","88888888888","99999999999"
            };

            if (repetidos.Contains(cpf)) return false;

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int digito1 = soma % 11;
            digito1 = digito1 < 2 ? 0 : 11 - digito1;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            int digito2 = soma % 11;
            digito2 = digito2 < 2 ? 0 : 11 - digito2;

            return cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2;
        }

    }
}
