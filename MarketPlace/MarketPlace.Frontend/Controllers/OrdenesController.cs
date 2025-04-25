using Marketplace.Application.Services;
using Marketplace.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Frontend.Controllers
{
    public class OrdenesController : Controller
    {
        private readonly OrdenService _ordenService;

        public OrdenesController(OrdenService ordenService)
        {
            _ordenService = ordenService;
        }

        // GET: Ordenes
        public async Task<IActionResult> Index()
        {
            var ordenes = await _ordenService.ObtenerOrdenes();
            return View(ordenes);
        }

        // GET: Ordenes/Detalles/{id}
        public async Task<IActionResult> Detalles(int id)
        {
            var orden = await _ordenService.ObtenerOrdenPorId(id);
            if (orden == null)
            {
                return NotFound();
            }
            return View(orden);
        }

        // GET: Ordenes/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Ordenes/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Orden orden)
        {
            if (ModelState.IsValid)
            {
                await _ordenService.CrearOrden(orden);
                return RedirectToAction(nameof(Index));
            }
            return View(orden);
        }

        // GET: Ordenes/Editar/{id}
        public async Task<IActionResult> Editar(int id)
        {
            var orden = await _ordenService.ObtenerOrdenPorId(id);
            if (orden == null)
            {
                return NotFound();
            }
            return View(orden);
        }

        // POST: Ordenes/Editar/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Orden orden)
        {
            if (id != orden.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _ordenService.ActualizarOrden(orden);
                return RedirectToAction(nameof(Index));
            }
            return View(orden);
        }

        // GET: Ordenes/Eliminar/{id}
        public async Task<IActionResult> Eliminar(int id)
        {
            var orden = await _ordenService.ObtenerOrdenPorId(id);
            if (orden == null)
            {
                return NotFound();
            }
            return View(orden);
        }

        // POST: Ordenes/Eliminar/{id}
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            await _ordenService.EliminarOrden(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
