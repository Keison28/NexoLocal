using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Repositories
{
    public class OrdenRepository
    {
        private readonly MarketplaceDbContext _context;

        public OrdenRepository(MarketplaceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Orden>> ObtenerOrdenesAsync()
        {
            return await _context.Ordenes
                .Include(o => o.Usuario)
                .Include(o => o.Producto)
                .ToListAsync();
        }

        public async Task<Orden> ObtenerOrdenPorIdAsync(int id)
        {
            return await _context.Ordenes
                .Include(o => o.Usuario)
                .Include(o => o.Producto)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task CrearOrdenAsync(Orden orden)
        {
            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarOrdenAsync(Orden orden)
        {
            _context.Ordenes.Update(orden);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarOrdenAsync(int id)
        {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden != null)
            {
                _context.Ordenes.Remove(orden);
                await _context.SaveChangesAsync();
            }
        }
    }
}
