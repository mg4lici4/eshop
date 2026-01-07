namespace EShop.Application.Dtos.Usuario
{
    public class GenerarSecretoResponseDto
    {
        public required string OtpauthUri { get; set; }
        public required long IdUsuario { get; set; }
    }
}
