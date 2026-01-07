namespace EShop.Application.Dtos.Usuario
{
    public class ActivarSegundoFaDto
    {
        public long IdUsuario { get; set; }
        public string Otp { get; set; } = default!;
    }
}
