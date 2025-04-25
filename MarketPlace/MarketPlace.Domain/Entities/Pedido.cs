using Marketplace.Domain.Entities;


namespace Marketplace.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Estado { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<DetallePedido> Detalles { get; set; }
    }
}