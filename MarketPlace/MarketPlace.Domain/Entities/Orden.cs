namespace Marketplace.Domain.Entities
{
    public class Orden
    {
        public int Id { get; set; }

        // Usuario que hizo la orden
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Producto que se pidió
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        // Fecha de la orden
        public DateTime Fecha { get; set; } = DateTime.Now;

        // Cantidad pedida
        public int Cantidad { get; set; }
    }
}
