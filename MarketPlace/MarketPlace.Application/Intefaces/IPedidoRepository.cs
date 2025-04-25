using Marketplace.Domain.Entities;

namespace Marketplace.Application.Interfaces
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> ObtenerPedidosAsync();
        Task<Pedido> ObtenerPedidoPorIdAsync(int id);
        Task CrearPedidoAsync(Pedido pedido);
        Task ActualizarPedidoAsync(Pedido pedido);
        Task EliminarPedidoAsync(int id);
    }
}
