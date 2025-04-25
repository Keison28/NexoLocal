using System.Threading.Tasks;

namespace Marketplace.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IProductoService ProductoService { get; }


        Task<int> GuardarCambiosAsync();
    }
}
