namespace Meraki.Cadastros.Domain.Clientes
{
    public class ClienteDadosCorporativo
    {
        protected ClienteDadosCorporativo(
            string razaoSocial,
            string nomeFantasia,
            string cnpj,
            string inscricaoEstadual,
            string inscricaoMunicipal)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            InscricaoMunicipal = inscricaoMunicipal;
        }

        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string Cnpj { get; private set; } = string.Empty;
        public string InscricaoEstadual { get; private set; }
        public string InscricaoMunicipal { get; private set; }

        public virtual Cliente Cliente { get; }

        public static ClienteDadosCorporativo Criar(
            string razaoSocial,
            string nomeFantasia,
            string cnpj,
            string inscricaoEstadual,
            string inscricaoMunicipal)
        {
            return new ClienteDadosCorporativo(
                razaoSocial,
                nomeFantasia,
                cnpj,
                inscricaoEstadual,
                inscricaoMunicipal);
        }

        public void AlterarDados(
            string razaoSocial,
            string nomeFantasia,
            string cnpj,
            string inscricaoEstadual,
            string inscricaoMunicipal)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            InscricaoMunicipal = inscricaoMunicipal;
        }
    }
}
