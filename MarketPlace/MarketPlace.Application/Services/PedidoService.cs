using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Repositories;

public class PedidoService
{
    private readonly PedidoRepository _PedidoRepository;

    public PedidoService(PedidoRepository pedidoRepository)
    {
        _PedidoRepository = pedidoRepository;
    }

    public Task<List<Pedido>> ObtenerPedido() => _PedidoRepository.ObtenerPedidosAsync();

    public Task<Pedido> ObtenerPedidoPorId(int id) => _PedidoRepository.ObtenerPedidoPorIdAsync(id);

    public Task CrearPedido(Pedido pedido) => _PedidoRepository.CrearPedidoAsync(pedido);

    public Task ActualizarPedido(Pedido pedido) => _PedidoRepository.ActualizarPedidoAsync(pedido);

    public Task EliminarPedido(int id) => _PedidoRepository.EliminarPedidoAsync(id);
}

   