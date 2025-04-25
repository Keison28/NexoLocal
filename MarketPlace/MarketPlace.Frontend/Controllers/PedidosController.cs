using Marketplace.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

public class PedidosController : Controller
{
    private readonly PedidoService _PedidoService;

    public PedidosController(PedidoService PedidoService)
    {
        _PedidoService = PedidoService;
    }

    // Acción para listar Pedidos
    public async Task<IActionResult> Index()
    {
        var Pedidos = await _PedidoService.ObtenerPedido();
        return View(Pedidos);
    }

    // GET: Pedidos/Crear
    public IActionResult Crear()
    {
        return View();
    }

    // POST: Pedidos/Crear
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Pedido pedido)
    {
        if (ModelState.IsValid)
        {
            await _PedidoService.CrearPedido(pedido);
            return RedirectToAction(nameof(Index)); // Después de guardar, redirige al listado
        }
        return View(pedido); // Si no es válido, vuelve a mostrar la vista
    }
    // GET: Pedidos/Editar/5
    public async Task<IActionResult> Editar(int id)
    {
        var pedido = await _PedidoService.ObtenerPedidoPorId(id);
        if (pedido == null)
        {
            return NotFound();
        }
        return View(pedido);
    }

    // POST: Pedidos/Editar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(int id, Pedido pedido)
    {
        if (id != pedido.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _PedidoService.ActualizarPedido(pedido);
            return RedirectToAction(nameof(Index)); // Redirige a la lista después de editar
        }
        return View(pedido);
    }

    public async Task<IActionResult> Eliminar(int id)
    {
        var Pedido = await _PedidoService.ObtenerPedidoPorId(id);
        if (Pedido == null)
        {
            return NotFound();
        }

        // Eliminar Pedido directamente
        await _PedidoService.EliminarPedido(id);

        // Redirigir a la vista de listado
        return RedirectToAction(nameof(Index));
    }
}


