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

                sw.Write(
                    "HTTP/1.1 200 OK\r\n" +
                    "\r\n" +
                    "You have requested file: {0}", message);


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



            #region 

            //HttpServer httpServer = new HttpServer();

            //while (true)
            //{
            //    httpServer.WaitForClient();
            //}

            //httpServer.CloseServer();
            //Console.ReadKey();

            #endregion

        }
    }
}