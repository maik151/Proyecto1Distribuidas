using System.Text.Json;

namespace App.Core
{
    public class BaseRequestDto
    {
        public string Modulo { get; set; } = "";
        public string Accion { get; set; } = "";
        public JsonElement Payload { get; set; }
    }
}
