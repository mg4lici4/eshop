namespace EShop.Domain.Entities
{
    public class PersonaEntity
    {
        public long IdPersona { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
