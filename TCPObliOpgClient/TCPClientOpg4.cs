using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPObliOpgClient
{
    internal class TCPClientOpg4
    {
        public static void Start()
        {
            string server = "localhost";
            int port = 7;

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
                    writer.WriteLine(command);

                    if (command == "close")
                    {
                        isRunning = false;
                    }

                    else if (command == "Random" || command == "Add" || command == "Subtract")
                    {
                        Console.WriteLine(reader.ReadLine());
                        
                        
                        string numbers = Console.ReadLine();
                        writer.WriteLine(numbers);
                        Console.WriteLine("Server response:" + reader.ReadLine());
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
