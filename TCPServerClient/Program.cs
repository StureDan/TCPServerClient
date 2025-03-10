using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using TCPServerClient;
using System.Text.Json;

namespace TCPEchoServer
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine("TCP Server");

            //Ændre port nummeret til 7 eller 8 alt efter hvilken server der skal køre
            int port = 8;
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                if (port == 7)
                {
                    Task.Run(() => ClientHandler.HandleClient(client));
                }
                else if (port == 8)
                { Task.Run(() => ClientHandlerJson.HandleClientWithJson(client)); }

            }
            listener.Stop();

        }
    }
}


