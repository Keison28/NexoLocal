using Marketplace.Application.Services;
using Marketplace.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly OrdenService _ordenService;

        public OrdenesController(OrdenService ordenService)
        {
            _ordenService = ordenService;
        }

        // GET: api/ordenes
        [HttpGet]
        public async Task<IActionResult> ObtenerOrdenes()
        {
            var ordenes = await _ordenService.ObtenerOrdenes();
            return Ok(ordenes);
        }

        // GET: api/ordenes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerOrdenPorId(int id)
        {
            var orden = await _ordenService.ObtenerOrdenPorId(id);
            if (orden == null)
            {
                return NotFound();
            }
            return Ok(orden);
        }

        // POST: api/ordenes
        [HttpPost]
        public async Task<IActionResult> CrearOrden([FromBody] Orden orden)
        {
            if (orden == null)
            {
                return BadRequest("Orden no válida.");
            }

            await _ordenService.CrearOrden(orden);
            return CreatedAtAction(nameof(ObtenerOrdenPorId), new { id = orden.Id }, orden);
        }

        // PUT: api/ordenes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarOrden(int id, [FromBody] Orden orden)
        {
            if (id != orden.Id)
            {
                return BadRequest("El ID de la orden no coincide.");
            }

            await _ordenService.ActualizarOrden(orden);
            return NoContent();
        }

        // DELETE: api/ordenes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarOrden(int id)
        {
            await _ordenService.EliminarOrden(id);
            return NoContent();
        }
    }
}
