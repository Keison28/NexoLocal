using Marketplace.Application.Interfaces;
using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly MarketplaceDbContext _context;

        public PedidoRepository(MarketplaceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> ObtenerPedidosAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedido> ObtenerPedidoPorIdAsync(int id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task CrearPedidoAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarPedidoAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarPedidoAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }
    }
}
