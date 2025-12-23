namespace EShop.Domain.Events.Usuario
{
    public class UsuarioCreadoEvent
    {
        public long IdUsuario {  get; set; }
        public string Nombre { get; set; } = default!;
        public DateTime FechaCreacion { get; set; }
    }
}
