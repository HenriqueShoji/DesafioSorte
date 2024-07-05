using DesafioSorte.Domain.Entities.Dtos;
using DesafioSorte.Domain.Entities.Models;
using DesafioSorte.Exceptions;
using DesafioSorte.Repositories.ClientesRepository;
using DesafioSorte.Repositories.PedidosRepository;

namespace DesafioSorte.Services
{
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository _pedidosRepository;
        private IClienteRepository _clienteRepository;
        public PedidoService(IPedidoRepository pedidoRepository, IClienteRepository clienteRepository)
        {
            _pedidosRepository = pedidoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task CadastraPedido(CadastraPedidoDto pedidoDTO)
        {
            try
            {
                if (pedidoDTO.EhValido())
                {
                    Clientes cliente = new Clientes
                    {
                        Nome = pedidoDTO.Nome,
                        Email = pedidoDTO.Email,
                    };

                    if (await _clienteRepository.VerificaEmailCadastrado(pedidoDTO.Email))
                        throw new EmailCadastradoException("Email já cadastrado!");

                    await _clienteRepository.CadastraCliente(cliente);

                    int clienteId = await _clienteRepository.ConsultaClienteId(pedidoDTO.Email);

                    if (clienteId == null)
                        throw new IdNaoEncontradoException("O Id do Cliente não foi encontrado!");

                    if (clienteId <= 0)
                        throw new IdInvalidoException("O Id do Cliente não é válido!");

                    Pedidos pedido = new Pedidos
                    {
                        ClienteId = clienteId,
                        DataPedido = DateTime.Now.AddHours(-3),
                        ValorTotal = pedidoDTO.ValorTotal
                    };

                    if (pedido.EhValido())
                        await _pedidosRepository.CadastraPedido(pedido);

                }
                else
                {
                    throw new CampoInvalidoException("Um ou mais campos não são válidos!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CadastraNovoPedido(NovoPedidoDto pedidoDto)
        {
            try
            {
                if (pedidoDto.EhValido())
                {
                    if (!await _clienteRepository.VerificaClienteCadastrado(pedidoDto.ClienteId))
                        throw new ClienteNaoCadastradoException($"Não existe nenhum cliente com Id: {pedidoDto.ClienteId}");

                    string nome = await _clienteRepository.BuscaNomeCliente(pedidoDto.ClienteId);

                    Pedidos pedido = new Pedidos
                    {
                        ClienteId = pedidoDto.ClienteId,
                        DataPedido = DateTime.Now.AddHours(-3),
                        ValorTotal = pedidoDto.ValorTotal
                    };

                    if (pedido.EhValido())
                        await _pedidosRepository.CadastraPedido(pedido);

                    return nome;
                }
                else
                {
                    throw new CampoInvalidoException("Um ou mais campos não são válidos!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
