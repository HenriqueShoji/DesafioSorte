using DesafioSorte.Domain.Entities.Dtos;

namespace DesafioSorte.Services
{
    public interface IPedidoService
    {
        public Task CadastraPedido(CadastraPedidoDto pedidoDto);
        public Task<string> CadastraNovoPedido(NovoPedidoDto pedidoDto);
    }
}
