namespace Meraki.Cadastros.Domain.Value_Objects
{
    public class Celular
    {
        public string Numero { get; }

        public Celular(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("Celular é obrigatório.");

            var digits = new string(numero.Where(char.IsDigit).ToArray());
            if (digits.Length != 11 || digits[2] != '9')
                throw new ArgumentException("Celular inválido. Deve ter 11 dígitos e começar com 9 no número.");

            Numero = digits;
        }
    }
}
