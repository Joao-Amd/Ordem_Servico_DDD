using Meraki.Cadastros.Domain.Clientes;
using Meraki.Cadastros.Domain.Clientes.Dtos;
using Meraki.Core.Patterns.Repositorys;
using Meraki.Core.Patterns.UnitOfWorks;

namespace Meraki.Cadastros.Aplication.Clientes
{
    public class AplicCliente : IAplicCliente
    {
        private readonly IRepBase<Cliente> _repCliente;
        private readonly IUnitOfWork _unitOfWork;

        public AplicCliente(IUnitOfWork unitOfWork, IRepBase<Cliente> repCliente)
        {
            _unitOfWork = unitOfWork;
            _repCliente = repCliente;
        }

        public void Inserir(ClienteDto dto)
        {
            var endereco = ClienteEndereco.Criar(
                dto.Logradouro,
                dto.Numero,
                dto.Complemento,
                dto.Bairro,
                dto.Cidade,
                dto.Uf,
                dto.Cep);

            var contato = ClienteContato.Criar(dto.Telefone, dto.Celular, dto.Email);

            var cliente = Cliente.Criar(
                dto.Nome,
                dto.TipoPessoa,
                dto.Cpf,
                dto.RazaoSocial,
                dto.NomeFantasia,
                dto.Cnpj,
                dto.InscricaoEstadual,
                dto.InscricaoMunicipal,
                endereco,
                contato);

            _repCliente.Inserir(cliente);
            _unitOfWork.Commit();
        }
    }
}
