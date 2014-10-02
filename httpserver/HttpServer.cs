using System;
using System.IO;
using System.Net.Sockets;

namespace httpserver
{
    /// <summary>
    /// Vores server.
    /// </summary>
    public class HttpServer
    {
        #region declare variable.
        public static readonly int DefaultPort = 8080; // Porten vi bruger til forbindelse.
        private static readonly string RootCatalog = @"C:/Users/Johan/Desktop/New folder/Hello_World.html"; //Destinationen af filen der vises, prøv evt. med Environment.GetFolderPath(Environment.SpecialFolder.Desktop); Men der kommer sikkerhed i vejen
        private static TcpListener serverSocket;// = new TcpListener(8080); //Socket der lytter til port 8080. Al forbindelse løber mellem sockets.

        private TcpClient connectionSocket;
        private static Stream ns;
           private FileStream fs;
        private StreamReader sr;
        private StreamWriter sw;         
            #endregion
        /// <summary>
        /// HttpServer constructor.
        /// </summary>
        public HttpServer()
        {
            
        }

      
        
     

        /// <summary>
        /// Starter serveren.
        /// </summary>
        public void StartServer()
        {

           serverSocket = new TcpListener(8080);
            serverSocket.Start();
            Console.WriteLine("Server activated");
            connectionSocket = serverSocket.AcceptTcpClient();
            ns = connectionSocket.GetStream();

           
        }

  
        /// <summary>
        /// Vores "indhold" fra vores server til klienten (Request+Response)
        /// </summary>
        public void dostuff()
        {
             sr = new StreamReader(ns);
             sw = new StreamWriter(ns);
             sw.AutoFlush = true; // enable automatic flushing
            
                try
                {
                    string message = sr.ReadLine(); // læser request fra browser
                    string[] words = new string[3];
                    words = message.Split(' '); //Det er nødvendigt at splitte beskeden op af hensyn til standarderne i protokollen, samt \r\n (carriage-return og line-feed)
                    Console.WriteLine("tester" + words.GetValue(1));
                    using (fs = File.OpenRead(RootCatalog)) //Åbner vores fil i den angivne destination som RootCatalog udgør.
                    {


                        //Request lines
                        sw.Write(
                            "HTTP/1.0 200 OK\r\n" +
                            "\r\n" +
                            "You have requested file: {0}", words[1]); //Grunden til [1] er at det er her destinationen ligger.

                        fs.CopyTo(sw.BaseStream); //Kopierer indholdet ovenover til streamwriteren, som så flusher.
                        sw.BaseStream.Flush();
                        sw.Flush();

                    }

                    
                    string answer = "GET /HTTP 1.0";
                    Console.WriteLine(answer);

                }
                    //Lukker vores forbindelser
                finally
                {
                    ns.Close();
                    connectionSocket.Close();
                    serverSocket.Stop();
                    sw.Close();
                    sr.Close();
                }
        }
    }

}
    

