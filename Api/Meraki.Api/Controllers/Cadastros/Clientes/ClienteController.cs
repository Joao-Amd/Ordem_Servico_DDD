using Meraki.Api.Controllers.Core;
using Meraki.Cadastros.Aplication.Clientes;
using Meraki.Cadastros.Aplication.Clientes.ViewModels;
using Meraki.Cadastros.Data.Base;
using Meraki.Cadastros.Domain.Clientes;
using Meraki.Cadastros.Domain.Clientes.Dtos;
using Meraki.Core.Base.QuerysParams;
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

        public ClienteController(INotification notificador, 
                                    IAplicCliente aplicCliente,
                                    IRepBaseCadastros<Cliente> repCliente) : base(notificador)
        {
            _aplicCliente = aplicCliente;
            _repCliente = repCliente;
        }

        [HttpGet]
        public async Task<ActionResult> Listar([FromQuery] QueryParams queryParams)
        {
            var entitys = await _repCliente.ListarPaginadoAsync<ClienteViewModel>(queryParams);

            return CustomResponse(HttpStatusCode.OK, entitys);
        }

        [HttpGet("ListarPorId/{id}")]
        public async Task<ActionResult> ListarPorId([FromRoute] Guid id)
        {
            var entity = await _repCliente.GetByIdAsync(id);

            return CustomResponse(HttpStatusCode.OK, entity);
        }

        [HttpPost]
        public async Task<ActionResult> Inserir([FromBody] ClienteDto dto)
        {
            await _aplicCliente.Inserir(dto);
            return CustomResponse(HttpStatusCode.Created);
        }

        [HttpPut("{idCliente}")]  
        public async Task<ActionResult> Alterar([FromRoute] Guid idCliente, [FromBody] ClienteDto dto)
        {
            await _aplicCliente.Alterar(idCliente, dto);
            return CustomResponse(HttpStatusCode.OK);
        }
    }
}
