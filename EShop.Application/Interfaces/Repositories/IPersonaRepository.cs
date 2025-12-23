using EShop.Domain.Entities;

namespace EShop.Application.Interfaces.Repositories
{
    public interface IPersonaRepository
    {
        Task<bool> RegistrarAsync(PersonaEntity personaEntity);
        Task<PersonaEntity> BuscarPorIdPersonaAsync(long idPersona);

    }
}
