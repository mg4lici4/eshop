namespace EShop.Domain.Entities
{
    public class UsuarioEntity
    {
        public long IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public long IdPersona { get; set; }
        public int IdOrigen { get; set; }
        public int Activo { get; set; }
        public int Bloqueo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaBloqueo { get; set; }
    }
}
