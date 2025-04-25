using Marketplace.Domain.DTOs;
using Marketplace.Domain.Entities;

namespace Marketplace.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> ObtenerTodosAsync();
        Task<Usuario> ObtenerPorIdAsync(int id);
        Task CrearAsync(Usuario Usuario);
        Task ActualizarAsync(Usuario Usuario);
        Task EliminarAsync(int id);
    }
}
