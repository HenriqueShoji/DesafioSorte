using DesafioSorte.Domain.Entities.Models;

namespace DesafioSorte.Repositories.ClientesRepository
{
    public class ClienteRepository : IClienteRepository
    {
        private IConfiguration _configuration { get; set; }
        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task CadastraCliente(Clientes cliente)
        {
            try
            {
                using (Context db = new Context(_configuration.GetConnectionString("Pedidos")))
                {
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> ConsultaClienteId(string email)
        {
            try
            {
                using (Context db = new Context(_configuration.GetConnectionString("Pedidos")))
                {
                    int id = db.Clientes.FirstOrDefault(x => x.Email == email).ClienteId;

                    return id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> VerificaEmailCadastrado(string email)
        {
            try
            {
                using (Context db = new Context(_configuration.GetConnectionString("Pedidos")))
                {
                    return db.Clientes.Any(x => x.Email == email);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public async Task<bool> VerificaClienteCadastrado(int id)
        {
            try
            {
                using (Context db = new Context(_configuration.GetConnectionString("Pedidos")))
                {
                    return db.Clientes.Any(x => x.ClienteId == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> BuscaNomeCliente(int id)
        {
            try
            {
                using (Context db = new Context(_configuration.GetConnectionString("Pedidos")))
                {
                    return db.Clientes.FirstOrDefault(x => x.ClienteId == id).Nome;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
