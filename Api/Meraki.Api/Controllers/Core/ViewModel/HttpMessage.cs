using System.Reflection.Metadata.Ecma335;

namespace Meraki.Api.Controllers.Core.ViewModel
{
    public class HttpMessage
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }
    }
}
