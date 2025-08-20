namespace Meraki.Cadastros.Domain.Value_Objects
{
    public class Cep
    {
        public Cep(){}

        public string Numero { get; }
        public Cep(string numero)
        {
            var cepNumerico = new string(numero.Where(char.IsDigit).ToArray());
            if (cepNumerico.Length != 8) throw new ArgumentException("CEP inválido.");

            Numero = cepNumerico;
        }
    }
}
