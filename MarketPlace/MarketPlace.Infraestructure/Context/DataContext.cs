using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Context
{
    public class MarketplaceDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }

        public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options) : base(options) { }
    }
}