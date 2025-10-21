using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LavanderiaAPI.Models;

namespace LavanderiaAPI.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<DetallePedido> DetallesPedido => Set<DetallePedido>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.Detalles)
                .WithOne(d => d.Pedido)
                .HasForeignKey(d => d.PedidoId);
        }

        public DbSet<PagoEmpleado> PagosEmpleados => Set<PagoEmpleado>();
        public DbSet<Gasto> Gastos => Set<Gasto>();
        public DbSet<ResumenSemanal> ResumenesSemanales => Set<ResumenSemanal>();


    }
}
