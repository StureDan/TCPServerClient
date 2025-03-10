using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TCPServerClient
{
    public class ClientHandlerJson
    {
        public static void HandleClientWithJson(TcpClient client)
        {
            using NetworkStream ns = client.GetStream();
            using StreamReader reader = new StreamReader(ns);
            using StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

            string? error = null;

            bool isRunning = true;

            while (isRunning)
            {
                string? jsonMessage = reader.ReadLine();
                if (jsonMessage == null) return;

                // Deserialiser JSON-indholdet
                var request = JsonSerializer.Deserialize<Request>(jsonMessage);

                switch (request?.Method)
                {
                    case "Random":
                        Random random = new Random();
                        string response = $"{random.Next(request.Tal1, request.Tal2)}";
                        var responseJson = JsonSerializer.Serialize(new Request { Response = response });
                        writer.WriteLine(responseJson);
                        break;
                    case "Add":
                        string resonseAdd = $"{request.Tal1 + request.Tal2}";
                        var responseJsonAdd = JsonSerializer.Serialize(new Request { Response = resonseAdd });
                        writer.WriteLine(responseJsonAdd);
                        break;
                    case "Subtract":
                        string responseSubtract = $"{request.Tal1 - request.Tal2}";
                        var responseJsonSubtract = JsonSerializer.Serialize(new Request { Response = responseSubtract });
                        writer.WriteLine(responseJsonSubtract);
                        break;
                    default:
                        error = "Invalid method";
                        isRunning = false;
                        break;
                }
            }
        }
    }

    // JSON-struktur til forespørgsler
    public class Request
    {
        public string Method { get; set; }
        public int Tal1 { get; set; }
        public int Tal2 { get; set; }
        public string Response { get; set; }

    }

    

}

