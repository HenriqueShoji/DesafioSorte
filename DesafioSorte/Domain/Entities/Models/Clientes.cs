using System.ComponentModel.DataAnnotations;

namespace DesafioSorte.Domain.Entities.Models
{
    public class Clientes
    {
        public int ClienteId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
