using Marketplace.Infrastructure.Interfaces;
using Marketplace.Infrastructure.Services;
using Marketplace.Infrastructure.Context;

namespace Marketplace.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MarketplaceDbContext _context;

        // Instancias privadas de los servicios
        private IProductoService _productoService;

        public UnitOfWork(MarketplaceDbContext context)
        {
            _context = context;
        }

        public IProductoService ProductoService =>
            _productoService ??= new ProductoService(_context);

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
