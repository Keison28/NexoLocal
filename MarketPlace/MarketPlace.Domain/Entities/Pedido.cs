using Marketplace.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Domain.Entities
{

    public class Pedido
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El ID de usuario es obligatorio.")]
        public int UsuarioId { get; set; }

        public List<DetallePedido> DetallesPedidos { get; set; }
    }

}