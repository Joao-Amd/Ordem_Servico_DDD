namespace Meraki.Cadastros.Domain.Value_Objects
{
    public class Telefone
    {
        public Telefone(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("Telefone é obrigatório.");

            var digits = new string(numero.Where(char.IsDigit).ToArray());
            if (digits.Length < 10 || digits.Length > 11)
                throw new ArgumentException("Telefone inválido. Deve conter entre 10 e 11 dígitos.");

            Numero = digits;
        }

        public string Numero { get; }
    }
}
