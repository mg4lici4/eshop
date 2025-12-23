using EShop.Domain.Entities;

namespace EShop.Application.Interfaces.Security
{
    public interface IJWTSecurity
    {
        string Generar(UsuarioEntity usuarioEntity, string jti, DateTime expiration);
    }
}
