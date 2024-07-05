using DesafioSorte.Domain.Entities.Models;

namespace DesafioSorte.Repositories.ClientesRepository
{
    public interface IClienteRepository
    {
        public Task CadastraCliente(Clientes cliente);
        public Task<int> ConsultaClienteId(string email);
        public Task<bool> VerificaEmailCadastrado(string email);
        public Task<bool> VerificaClienteCadastrado(int id);
        public Task<string> BuscaNomeCliente(int id);
    }
}
