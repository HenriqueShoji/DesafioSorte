using System.ComponentModel.DataAnnotations;

namespace DesafioSorte.Domain.Entities.Dtos
{
    public class CadastraPedidoDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public decimal ValorTotal { get; set; }
        public bool EhValido()
        {
            if (string.IsNullOrWhiteSpace(Nome) ||
                string.IsNullOrWhiteSpace(Email) ||
                ValorTotal == null || ValorTotal < 0)
                return false;

            return true;
        }
    }

}
