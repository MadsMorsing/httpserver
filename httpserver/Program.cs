using System;
using System.Collections.Generic;
using System.Linq;
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
            const string CLRF = "\r\n";
            Console.WriteLine("Hello http server");

            {
                try
                {
                    TcpListener serverSocket = new TcpListener(8080);
                    serverSocket.Start();


                    while (true)
                    {
                        TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                        //Socket connectionSocket = serverSocket.AcceptSocket();
                        Console.WriteLine("Server activated");

                        //Stream ns = connectionSocket.GetStream();
                        //Stream ns = new NetworkStream(connectionSocket);
                        //StreamReader sr = new StreamReader(ns);
                        //StreamWriter sw = new StreamWriter(ns);
                        //sw.AutoFlush = true; // enable automatic flushing


                        EchoService es = new EchoService(connectionSocket);

                        //Thread t = new Thread(es.doIt);
                       // t.Start();
                        es.doIt();

                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }


            }

        }


    }
}
