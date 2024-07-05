using DesafioSorte.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioSorte.Repositories
{
    public class Context : DbContext
    {
        private string _connectionString {  get; set; }
        public Context(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Context(DbContextOptions<Context> opts) :base(opts) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(x => x.ClienteId);
                entity.Property(x => x.Nome).HasMaxLength(100).IsRequired();
                entity.Property(x => x.Email).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.HasKey(x => x.PedidoId);
                entity.Property(x => x.ClienteId).IsRequired();
                entity.Property(x => x.DataPedido).IsRequired();
                entity.Property(x => x.ValorTotal).IsRequired();
            });
        }
    }
}
