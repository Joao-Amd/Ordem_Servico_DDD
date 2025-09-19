using Meraki.Cadastros.Data.Base;
using Meraki.Cadastros.Data.Patterns;
using Meraki.Estoque.Aplication.Estoques.Dtos;
using Meraki.Estoque.Domain.Estoques;
using Meraki.Estoque.Domain.Itens;

namespace Meraki.Estoque.Aplication.Estoques
{
    public class AplicItemEstoqueEstoque : IAplicItemEstoque
    {
        private readonly IRepBaseEstoque<ItemEstoque> _repositorioItemEstoque;
        private readonly IRepBaseEstoque<Item> _repositorioItem;
        private readonly IUnitOfWorkEstoque _unitOfWork;

        public AplicItemEstoqueEstoque(IRepBaseEstoque<ItemEstoque> repositorioItemEstoque,
                                       IRepBaseEstoque<Item> repositorioItem,
                                       IUnitOfWorkEstoque unitOfWork)
        {
            _repositorioItemEstoque = repositorioItemEstoque;
            _repositorioItem = repositorioItem;
            _unitOfWork = unitOfWork;
        }

        public async Task Atualizar(Guid idItemEstoque, ItemEstoqueDto itemEstoqueDto)
        {
            var itemEstoque = _repositorioItemEstoque.GetByIdAsync(idItemEstoque).Result;

            if (itemEstoque == null)
                throw new KeyNotFoundException($"Estoque não encontrado para o Id {itemEstoqueDto} informado.");

            itemEstoque.AtualizarSaldo(itemEstoqueDto.Saldo);

            await _unitOfWork.CommitAsync();
        }

        public async Task Inserir(ItemEstoqueDto itemEstoqueDto)
        {
            var item = _repositorioItem.GetByIdAsync(itemEstoqueDto.IdItem).Result;
            var itemEstoque = ItemEstoque.Criar(item);

            await _repositorioItemEstoque.InserirAsync(itemEstoque);
            await _unitOfWork.CommitAsync();
        }
    }
}
