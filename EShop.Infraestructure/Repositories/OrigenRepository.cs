using EShop.Application.Interfaces.Repositories;
using EShop.Domain.Entities;
using EShop.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infraestructure.Repositories
{
    public class OrigenRepository : IOrigenRepository
    {
        private readonly EShopDbContext _eShopDbContext;
        public OrigenRepository(EShopDbContext eShopDbContext)
        {
            _eShopDbContext = eShopDbContext;
        }

        public async Task<OrigenEntity> BuscarPorClaveAsync(string clave)
        {
            var origenEntity = await _eShopDbContext.Origenes.AsNoTracking().FirstOrDefaultAsync(o => o.Clave == clave);
            return origenEntity!;
        }

        public async Task<IEnumerable<OrigenEntity>> ObtenerRegistrosAsync()
        {
            var origenesEntities = await _eShopDbContext.Origenes.AsNoTracking().ToListAsync();
            return origenesEntities;
        }
    }
}
