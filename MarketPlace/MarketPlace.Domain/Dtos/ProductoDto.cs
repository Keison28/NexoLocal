namespace Marketplace.Domain.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }           // Opcional, útil para editar
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int UsuarioId { get; set; }    // Relación con el usuario
    }
}
