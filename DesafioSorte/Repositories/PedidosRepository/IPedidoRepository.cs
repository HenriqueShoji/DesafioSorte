using DesafioSorte.Domain.Entities.Models;

namespace DesafioSorte.Repositories.PedidosRepository
{
    public interface IPedidoRepository
    {
        public Task CadastraPedido(Pedidos pedido);
    }
}
