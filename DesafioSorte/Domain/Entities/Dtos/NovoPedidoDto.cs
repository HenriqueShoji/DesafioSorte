namespace DesafioSorte.Domain.Entities.Dtos
{
    public class NovoPedidoDto
    {
        public int ClienteId { get; set; }
        public decimal ValorTotal { get; set; }

        public bool EhValido()
        {
            if (ClienteId <= 0 || ValorTotal <= 0)
                return false;

            return true;
        }
    }
}
