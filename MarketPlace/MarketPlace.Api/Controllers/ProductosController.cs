using Marketplace.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly ProductoService _productoService;

    public ProductosController(ProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerProductos()
    {
        var productos = await _productoService.ObtenerProductos();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerProducto(int id)
    {
        var producto = await _productoService.ObtenerProductoPorId(id);
        if (producto == null)
            return NotFound();
        return Ok(producto);
    }

    [HttpPost]
    public async Task<IActionResult> CrearProducto([FromBody] Producto producto)
    {
        await _productoService.CrearProducto(producto);
        return CreatedAtAction(nameof(ObtenerProducto), new { id = producto.Id }, producto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarProducto(int id, [FromBody] Producto producto)
    {
        if (id != producto.Id)
            return BadRequest();

        await _productoService.ActualizarProducto(producto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarProducto(int id)
    {
        await _productoService.EliminarProducto(id);
        return NoContent();
    }
}
