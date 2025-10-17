// MiApp.Application/Common/Interfaces/IUsuarioRepository.cs
// Usaremos un DTO de ejemplo llamado UsuarioDto que debes crear en MiApp.Core
using App.Core.Dto;

public interface IUsuarioRepository
{
    UsuarioDto ObtenerPorId(int id);
}