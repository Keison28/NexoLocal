namespace Marketplace.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Dirección { get; set; }
        public string Teléfono { get; set; }
        public string Email { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
