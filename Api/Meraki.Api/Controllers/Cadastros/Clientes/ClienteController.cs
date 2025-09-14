using Meraki.Api.Controllers.Core;
using Meraki.Cadastros.Aplication.Clientes;
using Meraki.Cadastros.Aplication.Clientes.ViewModels;
using Meraki.Cadastros.Data.Base;
using Meraki.Cadastros.Domain.Clientes;
using Meraki.Cadastros.Domain.Clientes.Dtos;
using Meraki.Core.Notificador;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Meraki.Api.Controllers.Cadastros.Clientes
{
    [Route("Cadastros/Cliente")]
    public class ClienteController : ControllerMainListing< IRepBaseCadastros<Cliente>, ClienteViewModel>
    {
        private readonly IAplicCliente _aplicCliente;
        private readonly IRepBaseCadastros<Cliente> _repCliente;

        public ClienteController(INotification notificador, IRepBaseCadastros<Cliente> rep) : base(notificador, rep)
        {
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
    }
}
