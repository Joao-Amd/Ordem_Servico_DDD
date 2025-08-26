using Meraki.Cadastros.Domain.Clientes;

namespace Meraki.Cadastros.Aplication.Clientes.ViewModels
{
    public class DadosCorporativosViewModel
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }

        public static DadosCorporativosViewModel Criar(DadosCorporativo dados)
        {
            return new DadosCorporativosViewModel
            {
                RazaoSocial = dados.RazaoSocial,
                NomeFantasia = dados.NomeFantasia,
                Cnpj = dados.Cnpj,
                InscricaoEstadual = dados.InscricaoEstadual,
                InscricaoMunicipal = dados.InscricaoMunicipal,
            };
        }
    }
}
