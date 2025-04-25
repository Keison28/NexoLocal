using Microsoft.AspNetCore.Mvc;
public class ProductosController : Controller
{
    private readonly ProductoService _productoService;

    public ProductosController(ProductoService productoService)
    {
        _productoService = productoService;
    }

    // Acción para listar productos
    public async Task<IActionResult> Index()
    {
        var productos = await _productoService.ObtenerProductos();
        return View(productos);
    }

    // Acción para crear un nuevo producto
    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Producto producto)
    {
        if (ModelState.IsValid)
        {
            await _productoService.CrearProducto(producto);
            return RedirectToAction(nameof(Index)); // Redirige a la vista de listado
        }
        return View(producto);
    }

    // Acción para editar un producto
    public async Task<IActionResult> Editar(int id)
    {
        var producto = await _productoService.ObtenerProductoPorId(id);
        if (producto == null)
        {
            return NotFound();
        }
        return View(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(int id, Producto producto)
    {
        if (id != producto.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            await _productoService.ActualizarProducto(producto);
            return RedirectToAction(nameof(Index));
        }

        return View(producto);
    }

    // Acción para eliminar un producto
    public async Task<IActionResult> Eliminar(int id)
    {
        var producto = await _productoService.ObtenerProductoPorId(id);
        if (producto == null)
        {
            return NotFound();
        }
        return View(producto);
    }

    [HttpPost, ActionName("Eliminar")]
    public async Task<IActionResult> EliminarConfirmado(int id)
    {
        await _productoService.EliminarProducto(id);
        return RedirectToAction(nameof(Index));
    }
}
