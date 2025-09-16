using Meraki.Api.Controllers.Core;
using Meraki.Cadastros.Data.Base;
using Meraki.Core.Base.QuerysParams;
using Meraki.Core.Notificador;
using Meraki.Estoque.Aplication.Dtos;
using Meraki.Estoque.Aplication.Itens;
using Meraki.Estoque.Aplication.Itens.ViewModels;
using Meraki.Estoque.Domain.Itens;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Meraki.Api.Controllers.Estoques
{
    public class ItemController : ControllerMain
    {
        private readonly IAplicItem _aplicItem;
        private readonly IRepBaseCadastros<Item> _repItem;

        public ItemController(INotification notificador,
                                    IAplicItem aplicItem,
                                    IRepBaseCadastros<Item> repItem) : base(notificador)
        {
            _aplicItem = aplicItem;
            _repItem = repItem;
        }

        [HttpGet]
        public async Task<ActionResult> Listar([FromQuery] QueryParams queryParams)
        {
            var entitys = await _repItem.ListarPaginadoAsync<ItemViewModel>(queryParams);

            return CustomResponse(HttpStatusCode.OK, entitys);
        }

        [HttpGet("ListarPorId/{id}")]
        public async Task<ActionResult> ListarPorId([FromRoute] Guid id)
        {
            var entity = await _repItem.GetByIdAsync(id);

            return CustomResponse(HttpStatusCode.OK, entity);
        }

        [HttpPost]
        public async Task<ActionResult> Inserir([FromBody] ItemDto dto)
        {
            await _aplicItem.Inserir(dto);
            return CustomResponse(HttpStatusCode.Created);
        }

        [HttpPut("{idItem}")]
        public async Task<ActionResult> Alterar([FromRoute] Guid idItem, [FromBody] ItemDto dto)
        {
            await _aplicItem.Atualizar(idItem, dto);
            return CustomResponse(HttpStatusCode.OK);
        }
     }
}
