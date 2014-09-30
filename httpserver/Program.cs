﻿using System;
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

            //
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
                string[] words = message.Split(' ');
                string message1 = words[1].Replace("/", "");

                sw.Write(
                    "HTTP/1.1 200 OK\r\n" +
                    "\r\n" +
                    "You have requested file: {0}", message1);


                Console.WriteLine("client" + message);
                string answer = "GET /HTTP1.0";
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
