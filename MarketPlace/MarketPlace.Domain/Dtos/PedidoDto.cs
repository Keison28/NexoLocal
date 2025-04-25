using Marketplace.Domain.Entities;

namespace Marketplace.Domain.DTOs
{
    public class PedidoConDetallesDto
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetallePedidoDto> Detalles { get; set; }
    }

    public class DetallePedidoDto
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
    }

}
