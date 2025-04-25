using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Repositories;

namespace Marketplace.Application.Services
{
    public class PedidoService
    {
        private readonly PedidoRepository _pedidoRepository;

        public PedidoService(PedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<List<Pedido>> ObtenerPedidos()
        {
            return await _pedidoRepository.ObtenerTodosAsync();
        }

        public async Task<Pedido?> ObtenerPedidoPorId(int id)
        {
            return await _pedidoRepository.ObtenerPorIdAsync(id);
        }

        public async Task CrearPedido(Pedido pedido)
        {
            await _pedidoRepository.CrearAsync(pedido);
        }

        public async Task ActualizarPedido(Pedido pedido)
        {
            await _pedidoRepository.ActualizarAsync(pedido);
        }

        public async Task EliminarPedido(int id)
        {
            await _pedidoRepository.EliminarAsync(id);
        }
    }
}
