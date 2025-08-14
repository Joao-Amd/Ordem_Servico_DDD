using Meraki.Api.Controllers.Core;
using Meraki.Cadastros.Aplication.Clientes;
using Meraki.Cadastros.Domain.Clientes.Dtos;
using Meraki.Core.Notificador;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Meraki.Api.Controllers.Cadastros.Clientes
{
    [Route("Cadastros/Cliente")]
    public class ClienteController : ControllerMain
    {
        private readonly IAplicCliente _aplicCliente;

        public ClienteController(INotification notificador, IAplicCliente aplicCliente) : base(notificador)
        {
            _aplicCliente = aplicCliente;
        }

        [HttpPost]
        public async Task<ActionResult> Inserir([FromBody] ClienteDto dto)
        {
            _aplicCliente.Inserir(dto);
            return CustomResponse(HttpStatusCode.Created);
        }
    }
}
