// MiApp.Server/Listeners/SocketServer.cs
using App.Application.Login_Module;
using App.Core;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class SocketServer
{
    private readonly LoginServices _modulo1Service;
    public SocketServer(LoginServices modulo1Service)
    {
        _modulo1Service = modulo1Service;
    }
    public void Start()
    {
        var listener = new TcpListener(IPAddress.Any, 12345);
        listener.Start();
        Console.WriteLine("Servidor iniciado en el puerto 12345...");
        while (true)
        {
            var clientSocket = listener.AcceptSocket();
            Console.WriteLine("Cliente conectado!");
            Task.Run(() => HandleClient(clientSocket));
        }
    }
    private void HandleClient(Socket client)
    {
        try
        {
            byte[] buffer = new byte[1024];
            int bytesRecibidos = client.Receive(buffer);
            string jsonRequest = Encoding.UTF8.GetString(buffer, 0, bytesRecibidos);
            var request = JsonSerializer.Deserialize<BaseRequestDto>(jsonRequest);
            object result = null;
            if (request.Modulo == "MODULO1")
            {
                result = _modulo1Service.ProcesarAccion(request.Accion, request.Payload);
            }
            string jsonResponse = JsonSerializer.Serialize(result);
            client.Send(Encoding.UTF8.GetBytes(jsonResponse));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            client.Close();
        }
    }
}