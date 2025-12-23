namespace EShop.Application.Settings
{
    public class JWTSettings
    {
        public string Llave { get; set; } = default!;
        public int VigenciaEnMinutos { get; set; }
        public string Audiencia { get; set; } = default!;
        public string Emisor { get; set; } = default!;
    }
}
