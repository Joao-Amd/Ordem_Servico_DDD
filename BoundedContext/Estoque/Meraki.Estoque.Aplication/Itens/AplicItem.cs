using Meraki.Cadastros.Data.Base;
using Meraki.Cadastros.Data.Patterns;
using Meraki.Estoque.Aplication.Itens.Dtos;
using Meraki.Estoque.Aplication.Itens.ViewModels;
using Meraki.Estoque.Domain.Itens;
using Meraki.Estoque.Domain.Unidades;

namespace Meraki.Estoque.Aplication.Itens
{
    public class AplicItem : IAplicItem
    {
        private readonly IRepBaseEstoque<Item> _repositorioItem;
        private readonly IRepBaseEstoque<Unidade> _repositorioUnidade;
        private readonly IUnitOfWorkEstoque unitOfWork;

        public AplicItem(IRepBaseEstoque<Item> repositorioItem,
            IRepBaseEstoque<Unidade> repositorioUnidade,
            IUnitOfWorkEstoque unitOfWork)
        {
            _repositorioItem = repositorioItem;
            _repositorioUnidade = repositorioUnidade;
            this.unitOfWork = unitOfWork;
        }

        public async Task Atualizar(Guid idItem, ItemDto itemDto)
        {
            var item = _repositorioItem.GetByIdAsync(idItem).Result;
            if (item == null)
                throw new KeyNotFoundException($"Item não encontrado para o Id {itemDto} informado.");

            item.Atualizar(
                itemDto.Descricao,
                itemDto.Preco,
                itemDto.IdUnidade,
                itemDto.Ativo);

            await unitOfWork.CommitAsync();
        }

        public async Task Inserir(ItemDto itemDto)
        {
            var unidade = _repositorioUnidade.GetByIdAsync(itemDto.IdUnidade).Result;
            if (unidade == null)
                throw new KeyNotFoundException($"Unidade não encontrada para o Id {itemDto.IdUnidade} informado.");

            var item = Item.Criar(
                itemDto.Identificacao,
                itemDto.Descricao,
                itemDto.Preco,
                unidade);

           await _repositorioItem.InserirAsync(item);
           await unitOfWork.CommitAsync();
        }
    }
}
