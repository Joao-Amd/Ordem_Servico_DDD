using Meraki.Core.Base.QuerysParams;
using Meraki.Core.Notificador;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Meraki.Api.Controllers.Core
{
    public class ControllerMainListing<TRepository, TView> : ControllerMain
        where TRepository : IRep<TView>
        where TView : class, new()
    {
        private readonly TRepository _rep;
        public ControllerMainListing(INotification notificador, TRepository rep) : base(notificador)
        {
            _rep = rep;
        }

        [HttpGet]
        public async Task<ActionResult> Listar([FromQuery] QueryParams queryParams)
        {
            var entitys = await _rep.ListarPaginadoAsync<TView>(queryParams);

            return CustomResponse(HttpStatusCode.OK, entitys);
        }

        [HttpGet("ListarPorId/{id}")]
        public async Task<ActionResult> ListarPorId([FromRoute] Guid id)
        {
            var entity = await _rep.GetByIdAsync(id);

            return CustomResponse(HttpStatusCode.OK, entity);
        }
    }
}
