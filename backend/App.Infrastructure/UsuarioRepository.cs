using App.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public UsuarioDto ObtenerPorId(int id)
        {
            // Simulación de acceso a datos
            return new UsuarioDto
            {
                Id = id,
                Nombre = "Usuario" + id,
                Email = "usuario" + id + "@ejemplo.com"
            };
        }
    }
}
