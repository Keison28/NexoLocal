using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Acción para listar usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioRepository.ObtenerUsuariosAsync();
            return View(usuarios);
        }

        // Acción para crear un nuevo usuario (Vista GET)
        public IActionResult Crear()
        {
            return View();
        }

        // Acción para crear un nuevo usuario (Vista POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _usuarioRepository.CrearUsuarioAsync(usuario);
                return RedirectToAction(nameof(Index)); // Redirige a la vista de listado
            }
            return View(usuario); // Si no es válido, vuelve a mostrar la vista
        }

        // Acción para editar un usuario (Vista GET)
        public async Task<IActionResult> Editar(int id)
        {
            var usuario = await _usuarioRepository.ObtenerUsuarioPorIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // Acción para editar un usuario (Vista POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _usuarioRepository.ActualizarUsuarioAsync(usuario);
                return RedirectToAction(nameof(Index)); // Redirige a la lista de usuarios
            }
            return View(usuario); // Si no es válido, vuelve a mostrar la vista
        }

        // Acción para eliminar un usuario (Vista GET)
        public async Task<IActionResult> Eliminar(int id)
        {
            var usuario = await _usuarioRepository.ObtenerUsuarioPorIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // Acción para eliminar un usuario (Vista POST)
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            await _usuarioRepository.EliminarUsuarioAsync(id);
            return RedirectToAction(nameof(Index)); // Redirige a la lista de usuarios después de eliminar
        }
    }
}
