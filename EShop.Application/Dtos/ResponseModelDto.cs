using System.Text.Json.Serialization;

namespace EShop.Application.Dtos
{
    public class ResponseModelDto
    {
        public object Datos { get; set; }
        public string Mensage { get; set; } = string.Empty;

        [JsonConstructor]
        public ResponseModelDto(object datos, string mensage)
        {
            Datos = datos;
            Mensage = mensage;
        }

        public ResponseModelDto(object datos)
        {
            Datos = datos;
            Mensage = "Operación correcta.";
        }
        public ResponseModelDto(string mensaje)
        {
            Mensage = mensaje;
            Datos = null!;
        }
    }
}
