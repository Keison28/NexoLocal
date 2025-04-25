using Marketplace.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IProductoService ProductoService { get; }


        Task<int> GuardarCambiosAsync();
    }
}
