using Marketplace.Domain.Entities;

namespace Marketplace.Domain.DTOs
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }  // Relación con Usuario

        public List<DetallePedido> Detalles { get; set; }
    }
}
