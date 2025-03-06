using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace TCPServerClient
{
    public class ClientHandler
    {
        public static void HandleClient(TcpClient socket)
        {
            Console.WriteLine(socket.Client.RemoteEndPoint);
            NetworkStream ns = socket.GetStream();
            StreamReader reader = new StreamReader(ns); // read from client
            StreamWriter writer = new StreamWriter(ns); // write to client

            bool isRunning = true;

            while (isRunning)
            {
                string? message = reader.ReadLine();

                if (message == "Random")
                {
                    writer.WriteLine("Input numbers");
                    writer.Flush();
                    string? message1 = reader.ReadLine();
                    writer.WriteLine(RNum(message1));
                    writer.Flush();
                }

                else if (message == "Add")
                {
                    writer.WriteLine("Input numbers");
                    writer.Flush();
                    string? message2 = reader.ReadLine();
                    writer.WriteLine(ANum(message2));
                    writer.Flush();
                }

                else if (message == "Subtract")
                {
                    writer.WriteLine("Input numbers");
                    writer.Flush();
                    string? message3 = reader.ReadLine();
                    writer.WriteLine(SNum(message3));
                    writer.Flush();
                }

            }
            socket.Close();
        }

        public static int RNum(string message)
        {
            string[] numbers = message.Split(' ');

            if (numbers.Length != 2 || !int.TryParse(numbers[0], out int min) || !int.TryParse(numbers[1], out int max))
            {
                return -1; // Returner en fejlindikator, hvis input er forkert
            }

            if (min > max) // Sikrer at min er mindre end max
            {
                (min, max) = (max, min); // Bytter om på dem
            }

            Random random = new Random();
            return random.Next(min, max + 1); // Genererer et tal i det korrekte interval
        }

        public static int ANum(string message)
        {
            string[] numbers = message.Split(' ');
            int result = 0;
            foreach (string number in numbers)
            {
                result += int.Parse(number);
            }
            return result;
        }

        public static int SNum(string message)
        {
            string[] numbers = message.Split(' ');
            int result = int.Parse(numbers[0]);
            for (int i = 1; i < numbers.Length; i++)
            {
                result -= int.Parse(numbers[i]);
            }
            return result;
        }

    }


}
