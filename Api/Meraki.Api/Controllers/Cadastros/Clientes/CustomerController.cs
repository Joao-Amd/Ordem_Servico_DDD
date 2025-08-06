using Meraki.Api.Controllers.Core;
using Meraki.Core.Notificador;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Meraki.Api.Controllers.Cadastros.Clientes
{
    public class CustomerController : ControllerMain
    {
        public CustomerController(INotification notificador) : base(notificador)
        {
        }

        //public async Task<ActionResult> Insert()
        //{
            
        //}
    }
}
