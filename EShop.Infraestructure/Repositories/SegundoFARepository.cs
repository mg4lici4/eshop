using EShop.Application.Interfaces.Repositories;
using EShop.Domain.Entities;
using EShop.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infraestructure.Repositories
{
    public class SegundoFARepository : ISegundoFARepository
    {
        private readonly EShopDbContext _eShopDbContext;

        public SegundoFARepository(EShopDbContext eShopDbContext)
        {
            _eShopDbContext = eShopDbContext;
        }
        public async Task<SegundoFAEntity> BuscarPorIdUsuario(long idUsuario)
        {
            var segundoFAEntity = await _eShopDbContext.SegundosFA.AsNoTracking().FirstOrDefaultAsync(s => s.IdUsuario == idUsuario);
            return segundoFAEntity!;
        }

        public async Task<bool> RegistrarAsync(SegundoFAEntity segundoFAEntity)
        {
            await _eShopDbContext.SegundosFA.AddAsync(segundoFAEntity);
            var result = await _eShopDbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
