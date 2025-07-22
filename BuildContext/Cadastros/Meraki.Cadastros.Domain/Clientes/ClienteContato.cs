namespace Meraki.Cadastros.Domain.Clientes
{
    public class ClienteContato
    {
        protected ClienteContato(
            Guid codigoCliente,
            string? nome,
            string? telefone,
            string celular,
            string email)
        {
            Id = codigoCliente;
            Telefone = telefone;
            Celular = celular;
            Email = email;
        }

        public Guid Id { get; }
        public string? Telefone { get; private set; }
        public string Celular { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;

        public virtual Cliente Cliente { get; }

        public static ClienteContato Criar(
            Guid codigoCliente,
            string? nome,
            string? telefone,
            string celular,
            string email)
        {
            return new ClienteContato(codigoCliente, nome, telefone, celular, email);
        }

        public void AlterarContato(
            string? telefone,
            string celular,
            string email)
        {
            Telefone = telefone;
            Celular = celular;
            Email = email;
        }
    }
}
