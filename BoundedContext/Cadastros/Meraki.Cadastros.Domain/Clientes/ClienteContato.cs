using Meraki.Cadastros.Domain.Value_Objects;

namespace Meraki.Cadastros.Domain.Clientes
{
    public class ClienteContato
    {
        protected ClienteContato(
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

        public virtual Cliente Cliente { get; }

        public static ClienteContato Criar(
            string? telefone,
            string celular,
            string email)
        {
            return new ClienteContato(telefone, celular, email);
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
