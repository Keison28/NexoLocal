using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

public class ProductoRepository
{
    private readonly MarketplaceDbContext _context;

    public ProductoRepository(MarketplaceDbContext context)
    {
        _context = context;
    }

    public async Task<List<Producto>> ObtenerProductosAsync()
    {
        return await _context.Productos.ToListAsync();
    }

    public async Task<Producto> ObtenerProductoPorIdAsync(int id)
    {
        return await _context.Productos.FindAsync(id);
    }

    public async Task CrearProductoAsync(Producto producto)
    {
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarProductoAsync(Producto producto)
    {
        _context.Productos.Update(producto);
        await _context.SaveChangesAsync();
    }

    public async Task EliminarProductoAsync(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto != null)
        {
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }
    }
}
