using Meraki.Core.Notificador;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace Meraki.Api.Controllers.Core
{
    public class ControllerMain : Controller
    {
        private readonly INotification _notification;

        public ControllerMain(INotification notificador)
        {
            _notification = notificador;
        }

        protected bool ValidOperation()
        {
            return !_notification.Notified;
        }

        protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK, object result = null)
        {
            if (ValidOperation())
            {
                return new ObjectResult(result)
                {
                    StatusCode = (int)(statusCode),
                };
            }

            return new ObjectResult(new
            {
                success = false,
                errors = _notification.Message
            })
            {
                StatusCode = (int)(statusCode == HttpStatusCode.OK ? HttpStatusCode.BadRequest : statusCode)
            };
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState, HttpStatusCode errorStatusCode = HttpStatusCode.BadRequest)
        {
            if (!modelState.IsValid) ToNotificationErrorModelInvalid(modelState);
            return CustomResponse(errorStatusCode);
        }

        protected void ToNotificationErrorModelInvalid(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in errors)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                ToNotification(errorMsg);
            }
        }

        protected void ToNotification(string mensagem)
        {
            _notification.Message.Add(mensagem);
        }
    }
}
