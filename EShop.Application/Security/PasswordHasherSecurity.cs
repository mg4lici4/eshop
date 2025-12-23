using EShop.Application.Interfaces.Security;
using Microsoft.AspNetCore.Identity;

namespace EShop.Application.Security
{
    public class PasswordHasherSecurity : IPasswordHasherSecurity
    {
        private readonly PasswordHasher<object> _passwordHasher = new();
        public string Generar(string password)
        {
            return _passwordHasher.HashPassword(null!, password);
        }

        public bool Validar(string hashedPassword, string providedPassword)
        {
            var resultado = _passwordHasher.VerifyHashedPassword(null!, hashedPassword, providedPassword);
            return resultado == PasswordVerificationResult.Success;
        }
    }
}
