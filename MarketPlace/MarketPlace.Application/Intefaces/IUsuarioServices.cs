using Marketplace.Domain.DTOs;

namespace Marketplace.Application.Interfaces
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> ObtenerTodosAsync();
        Task<ProductoDto> ObtenerPorIdAsync(int id);
        Task CrearAsync(ProductoDto productoDto);
        Task ActualizarAsync(ProductoDto productoDto);
        Task EliminarAsync(int id);
    }
}
