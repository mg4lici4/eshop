namespace EShop.Application.Dtos.Usuario
{
    public class RegistrarUsuarioDto
    {
        public long IdPersona { get; set; }
        public string Contrasenia { get; set; } = null!;
        public string Aplicativo { get; set; } = null!;
    }
}
