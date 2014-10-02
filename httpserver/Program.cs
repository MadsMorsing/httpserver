using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace httpserver
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Logger log = new Logger();
            
            //log.start();//
            Console.WriteLine("Hello http server");
            TcpClient connectionSocket;
            TcpListener serverSocket;
           
            serverSocket = new TcpListener(8080); //Angiver porten til sockets kommunikation
            serverSocket.Start(); //Starter med at lytte.
            log.WriteToLog("Server started for the first time.", EventLogEntryType.Information, 1337);
            Console.WriteLine("Server activated");
            while (true)
            {

                connectionSocket = serverSocket.AcceptTcpClient();
                log.WriteToLog("Client opened", EventLogEntryType.Information, 1337);
                HttpServer server = new HttpServer(connectionSocket);
                Task.Factory.StartNew(() =>
                {
                    
                    //server.StartServer();
                    server.dostuff();
                });
                
              
            }

            


        }
                


        }
    }
