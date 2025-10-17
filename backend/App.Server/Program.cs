// MiApp.Server/Program.cs
using App.Application.Login_Module;
using App.Infrastructure;
// --- Inyección de Dependencias Manual ---
// 1. Crear instancias de abajo hacia arriba
IUsuarioRepository usuarioRepo = new UsuarioRepository();
LoginServices modulo1Service = new LoginServices(usuarioRepo);

// 2. Iniciar el servidor con los servicios necesarios
var server = new SocketServer(modulo1Service);
server.Start();