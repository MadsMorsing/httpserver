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
            
            Logger log = new Logger(); // logger
            Console.WriteLine("Starting server...");
            TcpClient connectionSocket;
            TcpListener serverSocket;
           
            serverSocket = new TcpListener(8080); //Angiver porten til sockets kommunikation
            serverSocket.Start(); //Starter med at lytte.
            log.WriteToLog("Server started for the first time.", EventLogEntryType.Information, 1337);//logger som kun bliver aktiveret ved første kørsel af program, ikke for hver tråd.
            Console.WriteLine("Server activated");
            while (true)
            {

                connectionSocket = serverSocket.AcceptTcpClient();
                log.WriteToLog("Client opened", EventLogEntryType.Information, 1337); // Info til log om at klienten er åbnet.
                HttpServer server = new HttpServer(connectionSocket); //Instanciering af vores HttpServer class.
                Task.Factory.StartNew(server.dostuff);//Task/Thread-pooling bruges til multi-threading, så flere forbindelser muliggøres.
 
                
              
            }

            


        }
                


        }
    }
