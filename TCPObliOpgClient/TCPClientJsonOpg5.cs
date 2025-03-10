using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TCPObliOpgClient
{
    public class TCPClientJsonOpg5
    {
        public static void Start()
        {
            string server = "localhost";
            int port = 8;

            try
            {
                using TcpClient client = new TcpClient(server, port);
                using NetworkStream ns = client.GetStream();
                using StreamReader reader = new StreamReader(ns);
                using StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

                Console.WriteLine("You have connected to the server");

                bool isRunning = true;

                while (isRunning)
                {
                    Console.WriteLine("Enter a command: The commands are the following, Random, Add and Subtract.");
                    string command = Console.ReadLine();

                    if (command == "close")
                    {
                        isRunning = false;
                    }

                    else if (command == "Random" || command == "Add" || command == "Subtract")
                    {
                        Console.WriteLine("Enter two numbers. The numbers must be seperated by space");
                        string[] numbers = Console.ReadLine().Split(' ');
                        var request = new { Method = command, Tal1 = int.Parse(numbers[0]), Tal2 = int.Parse(numbers[1]) };
                        string jsonRequest = JsonSerializer.Serialize(request);
                        writer.WriteLine(jsonRequest);
                        Console.WriteLine("Server response: " + reader.ReadLine());

                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        public class Request
        {
            public string Method { get; set; }
            public int Tal1 { get; set; }
            public int Tal2 { get; set; }
        }
    }
}
