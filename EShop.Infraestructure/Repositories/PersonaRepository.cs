using EShop.Application.Interfaces.Repositories;
using EShop.Domain.Entities;
using EShop.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infraestructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly EShopDbContext _eShopDbContext;

        public PersonaRepository(EShopDbContext eShopDbContext)
        {
            _eShopDbContext = eShopDbContext;
        }

        public async Task<PersonaEntity> BuscarPorIdPersonaAsync(long idPersona)
        {
            var personaEntity = await _eShopDbContext.Personas.AsNoTracking().FirstOrDefaultAsync(p => p.IdPersona == idPersona);
            return personaEntity!;
        }

        public async Task<bool> RegistrarAsync(PersonaEntity personaEntity)
        {
            try
            {
                await _eShopDbContext.Personas.AddAsync(personaEntity);
                var result = await _eShopDbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("ORA-00001"))
                    throw new DbUpdateException("Ya existe un registro con el correo proporcionado.", ex);

                throw new DbUpdateException("Ocurrio un error en la base de datos.", ex);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
