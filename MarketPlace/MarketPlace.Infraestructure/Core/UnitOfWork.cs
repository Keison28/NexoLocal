using Marketplace.Infrastructure.Interfaces;
using Marketplace.Infrastructure.Context;

namespace Marketplace.Infrastructure
{
    public class UnitOfWork 
    {
        private readonly MarketplaceDbContext _context;

        // Instancias privadas de los servicios
        private IProductoService _productoService;

        public UnitOfWork(MarketplaceDbContext context)
        {
            _context = context;
        }

       
        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
