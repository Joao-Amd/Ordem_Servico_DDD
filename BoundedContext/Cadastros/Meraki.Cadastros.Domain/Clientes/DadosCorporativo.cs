namespace Meraki.Cadastros.Domain.Clientes
{
    public class DadosCorporativo
    {
        protected DadosCorporativo(
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

        public static DadosCorporativo Criar(
            string razaoSocial,
            string nomeFantasia,
            string cnpj,
            string inscricaoEstadual,
            string inscricaoMunicipal)
        {
            return new DadosCorporativo(
                razaoSocial,
                nomeFantasia,
                cnpj,
                inscricaoEstadual,
                inscricaoMunicipal);
        }

        public void Atualizar(
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
