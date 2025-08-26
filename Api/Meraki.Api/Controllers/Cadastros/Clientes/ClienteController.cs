using Meraki.Api.Controllers.Core;
using Meraki.Cadastros.Aplication.Clientes;
using Meraki.Cadastros.Data.Base;
using Meraki.Cadastros.Domain.Clientes;
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
        private readonly IRepBaseCadastros<Cliente> _repCliente;

        public ClienteController(INotification notificador, IAplicCliente aplicCliente, IRepBaseCadastros<Cliente> repCliente) : base(notificador)
        {
            _aplicCliente = aplicCliente;
            _repCliente = repCliente;
        }

        [HttpPost]
        public async Task<ActionResult> Inserir([FromBody] ClienteDto dto)
        {
            _aplicCliente.Inserir(dto);
            return CustomResponse(HttpStatusCode.Created);
        }

        [HttpPut("{idCliente}")]  
        public async Task<ActionResult> Alterar([FromRoute] Guid idCliente, [FromBody] ClienteDto dto)
        {
            return CustomResponse(HttpStatusCode.OK, await _aplicCliente.Alterar(idCliente, dto));
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            var teste = await _repCliente.Teste(1, 10);

            return CustomResponse(HttpStatusCode.OK, teste);
        }
    }
}
