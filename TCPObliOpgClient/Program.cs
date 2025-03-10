using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Text.Json;

namespace TCPObliOpgClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ændre Client nummeret til 1 eller 2 for at vælge hvilken client der skal køre
            int Client = 2;

            if (Client == 1)
            {
                TCPClientOpg4.Start();
            }
            else if (Client == 2)
            {
                TCPClientJsonOpg5.Start();
                
            }

        }
    }
}
