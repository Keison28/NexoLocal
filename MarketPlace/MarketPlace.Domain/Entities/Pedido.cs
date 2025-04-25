namespace Marketplace.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        // Relación con Usuario
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Relación con DetallesPedidos
        public List<DetallePedido> DetallesPedidos { get; set; }
    }
}
