using Meraki.Cadastros.Domain.Value_Objects;

namespace Meraki.Cadastros.Domain.Clientes
{
    public class CustomerContact
    {
        protected CustomerContact(
            string? telefone,
            string celular,
            string email)
        {
            Telefone = string.IsNullOrEmpty(telefone)? null : new Telefone(telefone);
            Celular = new Celular(celular);
            Email = new Email(email);
        }

        public Telefone? Telefone { get; private set; }
        public Celular Celular { get; private set; } 
        public Email Email { get; private set; }

        public virtual Customer Cliente { get; }

        public static CustomerContact Criar(
            string? telefone,
            string celular,
            string email)
        {
            return new CustomerContact(telefone, celular, email);
        }

        public void AlterarContato(
            string? telefone,
            string celular,
            string email)
        {
            Telefone = string.IsNullOrEmpty(telefone) ? null : new Telefone(telefone);
            Celular = new Celular(celular);
            Email = new Email(email);
        }
    }
}
