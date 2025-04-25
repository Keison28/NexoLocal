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

    }
}