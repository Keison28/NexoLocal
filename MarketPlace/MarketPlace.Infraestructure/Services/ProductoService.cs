using Marketplace.Infrastructure.Interfaces;
using Marketplace.Domain.DTOs;
using Marketplace.Domain.Entities;
using Marketplace.Infrastructure;
using Marketplace.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Services
{
    public class ProductoService : IProductoService
    {
        private readonly MarketplaceDbContext _context;

        public ProductoService(MarketplaceDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoDto>> ObtenerTodosAsync()
        {
            return await _context.Productos
                .Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Stock = p.Stock,
                })
                .ToListAsync();
        }

        public async Task<ProductoDto> ObtenerPorIdAsync(int id)
        {
            var p = await _context.Productos.FindAsync(id);
            if (p == null) return null;

            return new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock,
            };
        }

        public async Task CrearAsync(ProductoDto dto)
        {
            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Stock = dto.Stock,
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(ProductoDto dto)
        {
            var producto = await _context.Productos.FindAsync(dto.Id);
            if (producto == null) return;

            producto.Nombre = dto.Nombre;
            producto.Precio = dto.Precio;
            producto.Stock = dto.Stock;

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }
    }
}
