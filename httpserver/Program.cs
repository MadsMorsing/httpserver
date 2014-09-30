using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace httpserver
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello http server");
            const string webg = "/r/n";
            string name = "localhost";
            //IPAddress ip = IPAddress.Parse("localhost");
            //Console.WriteLine(ip);
            
            TcpListener serverSocket = new TcpListener(8080);
            serverSocket.Start();

            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            //Socket connectionSocket = serverSocket.AcceptSocket();
            Console.WriteLine("Server activated");

            Stream ns = connectionSocket.GetStream();
            // Stream ns = new NetworkStream(connectionSocket);

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            string message = sr.ReadLine();
            string answer = "";
            while (message != null && message != "")
            {

                Console.WriteLine("Client: " + message);
                answer = message.ToUpper();
                sw.WriteLine(answer);
                message = sr.ReadLine();

            }

            ns.Close();
            connectionSocket.Close();
            serverSocket.Stop();

            //{
            //    try
            //    {
            //        TcpListener serverSocket = new TcpListener(8080);
            //        serverSocket.Start();


            //        while (true)
            //        {
            //            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            //            //Socket connectionSocket = serverSocket.AcceptSocket();
            //            Console.WriteLine("Server activated");

            //            //Stream ns = connectionSocket.GetStream();
            //            //Stream ns = new NetworkStream(connectionSocket);
            //            //StreamReader sr = new StreamReader(ns);
            //            //StreamWriter sw = new StreamWriter(ns);
            //            //sw.AutoFlush = true; // enable automatic flushing

            //            Console.WriteLine("Hello World");

            //            //EchoService es = new EchoService(connectionSocket);
            //            //es.doIt();

            //            // Thread t = new Thread(es.doIt);
            //            // t.Start();
            //            //es.doIt();

            //        }

            //    }
               
            //    catch (ArgumentOutOfRangeException e)
            //    {
            //        Console.WriteLine(e);
            //    }
               
                


            //}

        }


    }
}
