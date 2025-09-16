using Meraki.Cadastros.Data.Base;
using Meraki.Cadastros.Data.Patterns;
using Meraki.Estoque.Domain.Unidades;

namespace Meraki.Estoque.Data.Seedings
{
    public class UnidadesSeedings : IUnidadesSeedings
    {
        public readonly IRepBaseEstoque<Unidade> _repEstoque;
        public readonly IUnitOfWorkEstoque _unitOfWork;

        public UnidadesSeedings(IRepBaseEstoque<Unidade> estoqueContext, IUnitOfWorkEstoque unitOfWork)
        {
            _repEstoque = estoqueContext;
            _unitOfWork = unitOfWork;
        }

        public async Task Seed()
        {
            var possuiRegistros = _repEstoque.AnyAsync().Result;

            if (!possuiRegistros)
            {
                var unidades = new List<Unidade>
                {
                    new Unidade("UN", 1.0m, "Unidade Padrão"),
                    new Unidade("CX", 10.0m, "Caixa"),
                    new Unidade("KG", 1.0m, "Quilograma"),
                    new Unidade("G", 0.001m, "Grama"),
                    new Unidade("MG", 0.000001m, "Miligrama"),
                    new Unidade("L", 1.0m, "Litro"),
                    new Unidade("ML", 0.001m, "Mililitro"),
                    new Unidade("MT", 1.0m, "Metro"),
                    new Unidade("CM", 0.01m, "Centímetro"),
                    new Unidade("MM", 0.001m, "Milímetro"),
                    new Unidade("DZ", 12.0m, "Dúzia"),
                    new Unidade("PC", 1.0m, "Peça"),
                    new Unidade("PCT", 1.0m, "Pacote"),
                    new Unidade("FD", 1.0m, "Fardo"),
                    new Unidade("SC", 1.0m, "Saco"),
                    new Unidade("RL", 1.0m, "Rolo"),
                    new Unidade("TB", 1.0m, "Tubo"),
                    new Unidade("FR", 1.0m, "Frasco")
                };


                await _repEstoque.InserirAsync(unidades);
                await _unitOfWork.CommitAsync();
            }
        }

    }
}

