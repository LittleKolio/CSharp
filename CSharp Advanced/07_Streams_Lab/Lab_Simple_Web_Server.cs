using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Streams_Lab
{
    class Lab_Simple_Web_Server
    {
        private const int PortNumber = 1227;
        static void Main()
        {
            var tcpListener = new TcpListener(IPAddress.Any, PortNumber);
            tcpListener.Start();

            Console.WriteLine("Listening on port {0}...", PortNumber);

            while (true)
            {
                using (NetworkStream stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    byte[] request = new byte[4096];
                    stream.Read(request, 0, request.Length);
                    Console.WriteLine(Encoding.UTF8.GetString(request));

                    string html = string.Format("{0}{1}{2}{3} - {4}{2}{1}{0}",
                        "<html>", "<body>", "<h1>", "Welcome to my awesome site!", DateTime.Now);
                    byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
                    stream.Write(htmlBytes, 0, htmlBytes.Length);
                }
            }
            
        }
    }
}
