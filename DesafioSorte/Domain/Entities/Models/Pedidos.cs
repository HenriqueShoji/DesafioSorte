using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioSorte.Domain.Entities.Models
{
    public class Pedidos
    {
        public int PedidoId { get; set; }
        [Required]
        [ForeignKey("Clientes")]
        public int ClienteId { get; set; }
        [Required]
        public DateTime DataPedido { get; set; }
        [Required]
        public decimal ValorTotal { get; set; }

        public bool EhValido()
        {
            if (ClienteId == null || ClienteId < 0 ||
                ValorTotal == null || ValorTotal < 0)
                return false;

            return true;
        }
    }
}
