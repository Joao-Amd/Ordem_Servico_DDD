using Meraki.Api.Controllers.Core;
using Meraki.Cadastros.Data.Base;
using Meraki.Core.Base.QuerysParams;
using Meraki.Core.Notificador;
using Meraki.Estoque.Aplication.Itens.ViewModels;
using Meraki.Estoque.Aplication.Unidades.ViewModels;
using Meraki.Estoque.Domain.Estoques;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Meraki.Api.Controllers.Estoques
{
    public class UnidadeController : ControllerMain
    {
        private readonly IRepBaseEstoque<ItemEstoque> _repUnidades;

        public UnidadeController(INotification notificador) : base(notificador)
        {
        }

        [HttpGet]
        public async Task<ActionResult> Listar([FromQuery] QueryParams queryParams)
        {
            var entitys = await _repUnidades.ListarPaginadoAsync<UnidadeViewModel>(queryParams);

            return CustomResponse(HttpStatusCode.OK, entitys);
        }


        [HttpGet("ListarPorId/{id}")]
        public async Task<ActionResult> ListarPorId([FromRoute] Guid id)
        {
            var entity = await _repUnidades.GetByIdAsync(id);

            return CustomResponse(HttpStatusCode.OK, entity);
        }
    }
}
