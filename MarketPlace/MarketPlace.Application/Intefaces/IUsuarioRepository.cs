using Marketplace.Domain.Entities;

namespace Marketplace.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ObtenerUsuariosAsync();
        Task<Usuario> ObtenerUsuarioPorIdAsync(int id);
        Task CrearUsuarioAsync(Usuario Usuario);
        Task ActualizarUsuarioAsync(Usuario Usuario);
        Task EliminarUsuarioAsync(int id);
    }
}
