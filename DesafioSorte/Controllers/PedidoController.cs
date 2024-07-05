using DesafioSorte.Domain.Entities.Dtos;
using DesafioSorte.Exceptions;
using DesafioSorte.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSorte.Controllers
{
    [ApiController]
    public class PedidoController : Controller
    {
        private IPedidoService _pedidoService;
        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost("/cadastra-pedido")]
        public async Task<IActionResult> CadastraPedido(CadastraPedidoDto pedidoDto)
        {
            try
            {
                await _pedidoService.CadastraPedido(pedidoDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/novo-pedido")]
        public async Task<IActionResult> CadastraNovoPedido(NovoPedidoDto pedidoDto)
        {
            try
            {
                string nome = await _pedidoService.CadastraNovoPedido(pedidoDto);

                return Ok($"Pedido cadastrado para o cliente: {nome}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
