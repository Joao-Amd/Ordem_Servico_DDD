using Meraki.Cadastros.Aplication.Clientes.ViewModels;
using Meraki.Cadastros.Data.Base;
using Meraki.Cadastros.Domain.Clientes;
using Meraki.Cadastros.Domain.Clientes.Dtos;
using Meraki.Core.Patterns.UnitOfWorks;
namespace Meraki.Cadastros.Aplication.Clientes
{
    public class AplicCliente : IAplicCliente
    {
        private readonly IRepBaseCadastros<Cliente> _repCliente;
        private readonly IUnitOfWork _unitOfWork;

        public AplicCliente(IUnitOfWork unitOfWork, IRepBaseCadastros<Cliente> repCliente)
        {
            _unitOfWork = unitOfWork;
            _repCliente = repCliente;
        }

        public void Inserir(ClienteDto dto)
        {
            var cliente = Cliente.Criar(
                dto.Nome,
                dto.TipoPessoa,
                dto.Cpf,
                dto.RazaoSocial,
                dto.NomeFantasia,
                dto.Cnpj,
                dto.InscricaoEstadual,
                dto.InscricaoMunicipal);

            cliente.AtribuirContato(dto.Telefone, dto.Celular, dto.Email);

            cliente.AtribuirEndereco(
                dto.Logradouro,
                dto.Numero,
                dto.Complemento,
                dto.Bairro,
                dto.Cidade,
                dto.Uf,
                dto.Cep);

            _repCliente.InserirAsync(cliente);
            _unitOfWork.CommitAsync().Wait();
        }

        public async Task<ClienteViewModel> Alterar(Guid idCliente, ClienteDto dto)
        {
            var cliente  = await _repCliente.GetByIdAsync(idCliente)
                ?? throw new ArgumentException("Cliente de id {id cliente} não encontrado.");

            cliente.Atualizar(dto.Nome,
                              dto.TipoPessoa,
                              dto.Cpf,
                              dto.Telefone, 
                              dto.Celular,
                              dto.Email,
                              dto.Logradouro,
                              dto.Numero,
                              dto.Complemento,
                              dto.Bairro,
                              dto.Cidade,
                              dto.Uf,
                              dto.Cep);

            _unitOfWork.CommitAsync().Wait();

            return ClienteViewModel.Criar(cliente);
        }
    }
}
