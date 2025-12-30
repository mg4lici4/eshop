namespace EShop.Application.Dtos.Login
{
    public class ValidarOtpDto
    {
        
        public long IdUsuario { get; set; }
        public string Otp { get; set; } = default!;
    }
}
