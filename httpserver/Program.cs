using System;
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

                Task.Factory.StartNew(() =>
                {
                    server.StartServer();
                    server.dostuff();
                }).Wait();
                
              
            }

            


        }
                


        }
    }
