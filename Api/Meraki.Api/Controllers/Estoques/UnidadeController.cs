using Meraki.Api.Controllers.Core;
using Meraki.Cadastros.Data.Base;
using Meraki.Core.Base.QuerysParams;
using Meraki.Core.Notificador;
using Meraki.Estoque.Aplication.Unidades.ViewModels;
using Meraki.Estoque.Domain.Estoques;
using Meraki.Estoque.Domain.Unidades;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Meraki.Api.Controllers.Estoques
{
    [Route("Unidade")]
    public class UnidadeController : ControllerMain
    {
        private readonly IRepBaseEstoque<Unidade> _repUnidades;

        public UnidadeController(INotification notificador, 
                                 IRepBaseEstoque<Unidade> repUnidades) : base(notificador)
        {
            _repUnidades = repUnidades;
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
