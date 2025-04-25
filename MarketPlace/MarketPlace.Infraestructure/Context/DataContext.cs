using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Context
{
    public class MarketplaceDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public DbSet<Orden> Ordenes { get; set; }



        public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : base(options) { }
    }
}