using DesafioSorte.Domain.Entities.Models;

namespace DesafioSorte.Repositories.PedidosRepository
{
    public class PedidoRepository : IPedidoRepository
    {
        private IConfiguration _configuration { get; set; }
        public PedidoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task CadastraPedido(Pedidos pedido)
        {
            try
            {
                using (Context db = new Context(_configuration.GetConnectionString("Pedidos")))
                {
                    db.Pedidos.Add(pedido);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
