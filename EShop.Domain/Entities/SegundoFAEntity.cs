namespace EShop.Domain.Entities
{
    public class SegundoFAEntity
    {
        public long Id2FA { get; set; }
        public long IdUsuario { get; set; }
        public string Contrasenia { get; set; } = null!;
        public int Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
