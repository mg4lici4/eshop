using EShop.Domain.Entities;

namespace EShop.Application.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<bool> RegistrarAsync(UsuarioEntity usuarioEntity);
        Task<bool> ActualizarAsync(UsuarioEntity usuarioEntity);
        Task<UsuarioEntity> BuscarPorIdPersonaAsync(long idPersona);
        Task<UsuarioEntity> BuscarPorNombreAsync(string nombre);
    }
}
