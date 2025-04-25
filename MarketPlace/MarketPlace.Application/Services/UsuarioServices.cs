using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Repositories;

namespace Marketplace.Application.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> ObtenerUsuariosAsync()
        {
            return await _usuarioRepository.ObtenerUsuariosAsync();
        }

        public async Task<Usuario> ObtenerUsuarioPorIdAsync(int id)
        {
            return await _usuarioRepository.ObtenerUsuarioPorIdAsync(id);
        }

        public async Task CrearUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.CrearUsuarioAsync(usuario);
        }

        public async Task ActualizarUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.ActualizarUsuarioAsync(usuario);
        }

        public async Task EliminarUsuarioAsync(int id)
        {
            await _usuarioRepository.EliminarUsuarioAsync(id);
        }
    }
}
