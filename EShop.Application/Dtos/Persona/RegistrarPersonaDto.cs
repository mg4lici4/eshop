namespace EShop.Application.Dtos.Persona
{
    public class RegistrarPersonaDto
    {
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Celular { get; set; } = null!;
    }
}
