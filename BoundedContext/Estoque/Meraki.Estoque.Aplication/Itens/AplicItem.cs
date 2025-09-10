using Meraki.Cadastros.Data.Base;
using Meraki.Core.Patterns.UnitOfWorks;
using Meraki.Estoque.Aplication.Dtos;
using Meraki.Estoque.Aplication.Itens.ViewModels;
using Meraki.Estoque.Domain.Itens;
using Meraki.Estoque.Domain.Unidades;

namespace Meraki.Estoque.Aplication.Itens
{
    public class AplicItem : IAplicItem
    {
        private readonly IRepBaseEstoque<Item> _repositorioItem;
        private readonly IRepBaseEstoque<Unidade> _repositorioUnidade;
        private readonly IUnitOfWork unitOfWork;

        public AplicItem(IRepBaseEstoque<Item> repositorioItem,
            IRepBaseEstoque<Unidade> repositorioUnidade,
            IUnitOfWork unitOfWork)
        {
            _repositorioItem = repositorioItem;
            _repositorioUnidade = repositorioUnidade;
            this.unitOfWork = unitOfWork;
        }

        public List<ItemViewModel> Listar()
        {
            throw new NotImplementedException();
        }

        public ItemViewModel ObterPorId(Guid idItem)
        {
            var item = _repositorioItem.GetByIdAsync(idItem).Result;
            if (item == null)
                throw new KeyNotFoundException($"Item não encontrado para o Id {idItem} informado.");

            return ItemViewModel.Criar(item);
        }

        public void Atualizar(ItemDto itemDto)
        {
            var item = _repositorioItem.GetByIdAsync(itemDto.Id).Result;
            if (item == null)
                throw new KeyNotFoundException($"Item não encontrado para o Id {itemDto} informado.");

            item.Atualizar(
                itemDto.Descricao,
                itemDto.Preco,
                itemDto.IdUnidade,
                itemDto.Ativo);

            unitOfWork.Commit();
        }

        public void Inserir(ItemDto itemDto)
        {
            var unidade = _repositorioUnidade.GetByIdAsync(itemDto.IdUnidade).Result;
            if (unidade == null)
                throw new KeyNotFoundException($"Unidade não encontrada para o Id {itemDto.IdUnidade} informado.");

            var item = Item.Criar(
                itemDto.Identificacao,
                itemDto.Descricao,
                itemDto.Preco,
                unidade);

            _repositorioItem.InserirAsync(item).Wait();
            unitOfWork.Commit();
        }
    }
}
