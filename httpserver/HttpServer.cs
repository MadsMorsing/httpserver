using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace httpserver
{
    public class HttpServer
    {
        public static readonly int DefaultPort = 8080;
        private static readonly string RootCatalog = @"C:/Users/Mads Morsing/Desktop/httpserver_project.html";

        public HttpServer()
        {
            
        }

        public void StartServer()
        {


            const string webg = "/r/n";
            string name = "localhost";
            

            TcpListener serverSocket = new TcpListener(8080);
            serverSocket.Start();

            TcpClient connectionSocket = serverSocket.AcceptTcpClient();

            Console.WriteLine("Server activated");

            Stream ns = connectionSocket.GetStream();


            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            try
            {
                string message = sr.ReadLine();
                string[] words = new string[3];
                words = message.Split(' ');
                Console.WriteLine("tester" + words.GetValue(1));

                using (FileStream fs = File.OpenRead(RootCatalog))
                {
                    fs.CopyTo(sw.BaseStream);
                    sw.BaseStream.Flush();
                    sw.Flush();


                    sw.Write(
                        "HTTP/1.1 200 OK\r\n" +
                        "\r\n" +
                        "You have requested file: {0}", words[1]);

                }
                //Console.WriteLine("client" + message);
                string answer = "GET /HTTP 1.1";
                Console.WriteLine(answer);

            }

            finally
            {
                ns.Close();
                connectionSocket.Close();
                serverSocket.Stop();
            }
        }
    }
}
