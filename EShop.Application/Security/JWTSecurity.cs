using EShop.Application.Interfaces.Security;
using EShop.Application.Settings;
using EShop.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EShop.Application.Security
{
    public class JWTSecurity : IJWTSecurity
    {
        private readonly JWTSettings _jwtSettings;
        public JWTSecurity(IOptions<JWTSettings> config)
        {
            _jwtSettings = config.Value;
        }
        public string Generar(UsuarioEntity usuarioEntity, string jti, DateTime expiration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Llave));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuarioEntity.IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, usuarioEntity.Nombre),
                new Claim(JwtRegisteredClaimNames.Jti, jti)
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Emisor,
                audience: _jwtSettings.Audiencia,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
