namespace Meraki.Cadastros.Domain.Value_Objects
{
    public class Email
    {
        public Email(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("Email é obrigatório.");


            try
            {
                var addr = new System.Net.Mail.MailAddress(endereco);
                Endereco = addr.Address;
            }
            catch
            {
                throw new ArgumentException("Email inválido.");
            }
        }

        public string Endereco { get; }

    }
}
