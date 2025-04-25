using Marketplace.Domain.Entities;
using Marketplace.Infrastructure.Repositories;

namespace Marketplace.Application.Services
{
    public class OrdenService
    {
        private readonly OrdenRepository _ordenRepository;

        public OrdenService(OrdenRepository ordenRepository)
        {
            _ordenRepository = ordenRepository;
        }

        public async Task<List<Orden>> ObtenerOrdenes()
        {
            return await _ordenRepository.ObtenerOrdenesAsync();
        }

        public async Task<Orden> ObtenerOrdenPorId(int id)
        {
            return await _ordenRepository.ObtenerOrdenPorIdAsync(id);
        }

        public async Task CrearOrden(Orden orden)
        {
            await _ordenRepository.CrearOrdenAsync(orden);
        }

        public async Task ActualizarOrden(Orden orden)
        {
            await _ordenRepository.ActualizarOrdenAsync(orden);
        }

        public async Task EliminarOrden(int id)
        {
            await _ordenRepository.EliminarOrdenAsync(id);
        }
    }
}
