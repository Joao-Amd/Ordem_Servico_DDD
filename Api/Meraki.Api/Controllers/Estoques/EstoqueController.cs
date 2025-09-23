using Meraki.Api.Controllers.Core;
using Meraki.Cadastros.Data.Base;
using Meraki.Core.Base.QuerysParams;
using Meraki.Core.Notificador;
using Meraki.Estoque.Aplication.Estoques;
using Meraki.Estoque.Aplication.Estoques.Dtos;
using Meraki.Estoque.Aplication.Estoques.ViewModels;
using Meraki.Estoque.Domain.Estoques;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Meraki.Api.Controllers.Estoques
{
    [Route("Estoque")]
    public class EstoqueController : ControllerMain
    {
        private readonly IRepBaseEstoque<ItemEstoque> _repItemEstoque;
        private readonly IAplicItemEstoque _aplicItemEstoque;

        public EstoqueController(INotification notificador,
                                 IRepBaseEstoque<ItemEstoque> repItemEstoque,
                                 IAplicItemEstoque aplicItemEstoque) : base(notificador)
        {
            _repItemEstoque = repItemEstoque;
            _aplicItemEstoque = aplicItemEstoque;
        }

        [HttpGet]
        public async Task<ActionResult> Listar([FromQuery] QueryParams queryParams)
        {
            var entitys = await _repItemEstoque.ListarPaginadoAsync<ItemEstoqueViewModel>(queryParams);

            return CustomResponse(HttpStatusCode.OK, entitys);
        }

        [HttpPost]
        public async Task<ActionResult> Inserir([FromBody] ItemEstoqueDto dto)
        {
            await _aplicItemEstoque.Inserir(dto);
            return CustomResponse(HttpStatusCode.Created);
        }

        [HttpPut("{idItem}")]
        public async Task<ActionResult> Alterar([FromRoute] Guid idItem, [FromBody] ItemEstoqueDto dto)
        {
            await _aplicItemEstoque.Atualizar(idItem, dto);
            return CustomResponse(HttpStatusCode.OK);
        }
    }
}
