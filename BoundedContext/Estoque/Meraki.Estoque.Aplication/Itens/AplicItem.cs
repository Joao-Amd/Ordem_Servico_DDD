using Meraki.Cadastros.Data.Base;
using Meraki.Cadastros.Data.Patterns;
using Meraki.Estoque.Aplication.Itens.Dtos;
using Meraki.Estoque.Domain.Estoques;
using Meraki.Estoque.Domain.Itens;
using Meraki.Estoque.Domain.Unidades;

namespace Meraki.Estoque.Aplication.Itens
{
    public class AplicItem : IAplicItem
    {
        private readonly IRepBaseEstoque<Item> _repositorioItem;
        private readonly IRepBaseEstoque<Unidade> _repositorioUnidade;
        private readonly IRepBaseEstoque<ItemEstoque> _repItemEstoque;
        private readonly IUnitOfWorkEstoque _unitOfWork;

        public AplicItem(IRepBaseEstoque<Item> repositorioItem,
            IRepBaseEstoque<Unidade> repositorioUnidade,
            IUnitOfWorkEstoque unitOfWork,
            IRepBaseEstoque<ItemEstoque> repItemEstoque)
        {
            _repositorioItem = repositorioItem;
            _repositorioUnidade = repositorioUnidade;
            _unitOfWork = unitOfWork;
            _repItemEstoque = repItemEstoque;
        }

        public async Task Atualizar(Guid idItem, ItemDto itemDto)
        {
            var item = _repositorioItem.GetByIdAsync(idItem).Result;
            if (item == null)
                throw new KeyNotFoundException($"Item não encontrado para o Id {itemDto} informado.");

            item.Atualizar(
                itemDto.Descricao,
                itemDto.Preco,
                itemDto.IdUnidade);

            await _unitOfWork.CommitAsync();
        }

        public async Task Inserir(ItemDto itemDto)
        {
            var unidade = _repositorioUnidade.GetByIdAsync(itemDto.IdUnidade).Result;
            if (unidade == null)
                throw new KeyNotFoundException($"Unidade não encontrada para o Id {itemDto.IdUnidade} informado.");

            var item = Item.Criar(itemDto.Descricao, itemDto.Preco, unidade);

           await _repositorioItem.InserirAsync(item);
           await _unitOfWork.CommitAsync();
        }

        public async Task AtivarInativar(Guid iditem)
        {
            var item = await _repositorioItem.GetByIdAsync(iditem);

            if (item == null)
                throw new KeyNotFoundException($"Item não encontrado para o Id {iditem} informado.");

            var itemEstoque = _repItemEstoque.FirstOrDefault(e => e.IdItem == iditem);

            if (itemEstoque?.Saldo > 0)
                throw new InvalidOperationException("Não é possível inativar o item pois existe saldo em estoque.");

            item.AtivarInativar();

            await _unitOfWork.CommitAsync();
        }
    }
}
