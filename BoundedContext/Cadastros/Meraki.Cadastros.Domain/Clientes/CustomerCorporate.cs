namespace Meraki.Cadastros.Domain.Clientes
{
    public class CustomerCorporate
    {
        protected CustomerCorporate(
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

        public virtual Customer Cliente { get; }

        public static CustomerCorporate Criar(
            string razaoSocial,
            string nomeFantasia,
            string cnpj,
            string inscricaoEstadual,
            string inscricaoMunicipal)
        {
            return new CustomerCorporate(
                razaoSocial,
                nomeFantasia,
                cnpj,
                inscricaoEstadual,
                inscricaoMunicipal);
        }

        public void Alter(
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
