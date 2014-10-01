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

            HttpServer server = new HttpServer();

            while (true)
            {
                server.StartServer();
            }

            const string webg = "/r/n";
            string name = "localhost";
            
            
            


      

            
             
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
