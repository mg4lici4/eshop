using EShop.Domain.Entities;

namespace EShop.Application.Interfaces.Repositories
{
    public interface IOrigenRepository
    {
        Task<IEnumerable<OrigenEntity>> ObtenerRegistrosAsync();
        Task<OrigenEntity> BuscarPorClaveAsync(string clave);
    }
}
