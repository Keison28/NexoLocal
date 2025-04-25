public class ProductoService
{
    private readonly ProductoRepository _productoRepository;

    public ProductoService(ProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public Task<List<Producto>> ObtenerProductos() => _productoRepository.ObtenerProductosAsync();

    public Task<Producto> ObtenerProductoPorId(int id) => _productoRepository.ObtenerProductoPorIdAsync(id);

    public Task CrearProducto(Producto producto) => _productoRepository.CrearProductoAsync(producto);

    public Task ActualizarProducto(Producto producto) => _productoRepository.ActualizarProductoAsync(producto);

    public Task EliminarProducto(int id) => _productoRepository.EliminarProductoAsync(id);
}
