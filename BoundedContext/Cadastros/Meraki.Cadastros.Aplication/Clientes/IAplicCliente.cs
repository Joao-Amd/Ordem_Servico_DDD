using Meraki.Cadastros.Aplication.Clientes.ViewModels;
using Meraki.Cadastros.Domain.Clientes.Dtos;

namespace Meraki.Cadastros.Aplication.Clientes
{
    public interface IAplicCliente
    {
        Task Inserir(ClienteDto dto);
        Task<ClienteViewModel> Alterar(Guid idCliente, ClienteDto dto);
    }
}
