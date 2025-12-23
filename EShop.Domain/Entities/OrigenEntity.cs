namespace EShop.Domain.Entities
{
    public class OrigenEntity
    {
        public int IdOrigen { get; set; }
        public string Nombre { get; set; } = default!;
        public string Clave { get; set; } = default!;         
        public int Estatus { get; set; }
        public DateTime FechaCreacion { get; set; } 
        public DateTime? FechaActualizacion { get; set; }
    }
}
