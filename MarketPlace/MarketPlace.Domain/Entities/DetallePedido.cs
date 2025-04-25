namespace Marketplace.Domain.Entities
{
    public class DetallePedido
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        // Relación con Producto
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        // Relación con Pedido
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}
