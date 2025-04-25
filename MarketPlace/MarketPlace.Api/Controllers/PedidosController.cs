using Marketplace.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly PedidoService _pedidoService;

    public PedidoController(PedidoService PedidoService)
    {
        _pedidoService = PedidoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerPedidos()
    {
        var pedidos = await _pedidoService.ObtenerPedido();
        return Ok(pedidos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPedido(int id)
    {
        var pedido = await _pedidoService.ObtenerPedidoPorId(id);
        if (pedido == null)
            return NotFound();
        return Ok(pedido);
    }

    [HttpPost]
    public async Task<IActionResult> CrearPedido([FromBody] Pedido pedido)
    {
        await _pedidoService.CrearPedido(pedido);
        return CreatedAtAction(nameof(ObtenerPedidos), new { id = pedido.Id }, pedido);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarPedido(int id, [FromBody] Pedido pedido)
    {
        if (id != pedido.Id)
            return BadRequest();

        await _pedidoService.ActualizarPedido(pedido);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarPedido(int id)
    {
        await _pedidoService.EliminarPedido(id);
        return NoContent();
    }
}
