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
            NetworkStream netstream;
            while (true)
            {
                serverSocket.Start();

                TcpClient connectionSocket = serverSocket.AcceptTcpClient();

                Console.WriteLine("Server activated");
               
            

                NetworkStream ns = connectionSocket.GetStream();

                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true; // enable automatic flushing


                    string message = sr.ReadLine();
                Console.WriteLine("client" + message);
                string answer = "GET /HTTP/1.0";
                Console.WriteLine(answer);                    
                    //while (message != null && message != "")
                   

                        //Console.WriteLine("Client: " + message);
                        //answer = message.ToUpper();
                        //sw.WriteLine(answer);
                        //message = sr.ReadLine();

                        string[] tekst = new string[3]; 
                        tekst = message.Split(' ');

                        Console.WriteLine(tekst.GetValue(1)+"test");

                        //sw.Write(
                        //    "HTTP/1.0 200 Ok\r\n" +
                        //"\r\n" + 
                        //"You have requested file: {0}", message);
                            
                        sw.Write(answer);
                Console.WriteLine(answer);

                    }

               
            

        }


    }
}
