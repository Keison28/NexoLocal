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

    // Acción para crear un nuevo Pedido
    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Pedido Pedido)
    {
        if (ModelState.IsValid)
        {
            await _PedidoService.CrearPedido(Pedido);
            return RedirectToAction(nameof(Index)); // Redirige a la vista de listado
        }
        return View(Pedido);
    }

    // Acción para editar un Pedido
    public async Task<IActionResult> Editar(int id)
    {
        var Pedido = await _PedidoService.ObtenerPedidoPorId(id);
        if (Pedido == null)
        {
            return NotFound();
        }
        return View(Pedido);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(int id, Pedido Pedido)
    {
        if (id != Pedido.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _PedidoService.ActualizarPedido(Pedido);
            return RedirectToAction(nameof(Index));
        }

        return View(Pedido);
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


