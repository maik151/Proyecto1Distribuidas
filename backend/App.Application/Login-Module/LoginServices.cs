using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace App.Application.Login_Module
{
   
    public class LoginServices : ILoginServices
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public object ProcesarAccion(string accion, JsonElement payload)
        {
            // Lógica de enrutamiento para este módulo
            if (accion == "GET_USER")
            {
                var userId = payload.GetProperty("id").GetInt32();
                return _usuarioRepository.ObtenerPorId(userId);
            }
            return null;
        }
    }
}
