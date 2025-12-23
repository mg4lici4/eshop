namespace EShop.Application.Interfaces.Security
{
    public interface IPasswordHasherSecurity
    {
        string Generar(string password);
        bool Validar(string hashedPassword, string providedPassword);
    }
}
