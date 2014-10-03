using System;
using System.Diagnostics;
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
        private static readonly string RootCatalog = @"C:/Users/Johan/Desktop/New folder/Hello_World.html"; //Destinationen af filen der vises, prøver evt. med Environment.GetFolderPath(Environment.SpecialFolder.Desktop); Men der kommer sikkerhed i vejen, så filen ikke kan åbnes
        private static TcpListener serverSocket;// = new TcpListener(8080); //Socket der lytter til port 8080. Al forbindelse løber mellem sockets.
        Logger log = new Logger();
        private TcpClient connectionSocket;
        private static Stream ns;
           private FileStream fs;
        private StreamReader sr;
        private StreamWriter sw;
        private string Date = DateTime.Now.ToString();
            #endregion

   /// <summary>
   /// HttpServer constructor med parametrene TcpClient:
   /// </summary>
   /// <param name="client"> TcpClienten </param>
        public HttpServer(TcpClient client)
        {
            connectionSocket = client;
        }
 
        /// <summary>
        /// Vores "indhold" fra vores server til klienten (Request+Response)
        /// </summary>
        public void dostuff()
        {
            ns = connectionSocket.GetStream();
             sr = new StreamReader(ns);
             sw = new StreamWriter(ns);
             sw.AutoFlush = true; // enable automatic flushing

                try
                {
                    string message = sr.ReadLine(); // læser request fra browser
                    string[] words = new string[3];
                    words = message.Split(' '); //Det er nødvendigt at splitte beskeden op af hensyn til standarderne i protokollen, samt \r\n (carriage-return og line-feed)
                    Console.WriteLine("Starting new" + words.GetValue(1));
                    if (!File.Exists(RootCatalog))
                    { 
                     E404();   
                    }
                    else
                    using (fs = File.OpenRead(RootCatalog)) //Åbner vores fil i den angivne destination som RootCatalog udgør.
                    {
                        //Request lines
                        sw.Write(
                            "HTTP/1.0 200 OK\r\n" +
                            "\r\n" +
                            "Current Time: {1} \r\nYou have requested file: {0}", words[1], Date); //Grunden til [1] er at det er her destinationen ligger.
                        log.WriteToLog("Requested", EventLogEntryType.Information, 1337);
                        fs.CopyTo(sw.BaseStream); //Kopierer indholdet ovenover til streamwriteren, som så flusher.
                        sw.BaseStream.Flush();
                        sw.Flush();
                    } 
                    string answer = "GET /HTTP 1.0"; //Til vores cmd-promt / server del
                    Console.WriteLine(answer);
                }
                    //Lukker vores forbindelser
                finally
                {
                    Close();
                }
        }

        /// <summary>
        /// Håndterer Error 404.
        /// </summary>
        private void E404()
    {

        string message = sr.ReadLine(); // læser request fra browser
        string[] words = new string[3];
        words = message.Split(' '); //Det er nødvendigt at splitte beskeden op af hensyn til standarderne i protokollen, samt \r\n (carriage-return og line-feed)

          sw.Write(
                        "HTTP/1.0 404 FILE NOT FOUND\r\n" +
                        "\r\n" +
                        "Error 404: File Not Found: {0}", words[1]); //Grunden til [1] er at det er her destinationen ligger.
                        log.WriteToLog("404: File not found", EventLogEntryType.Error, 1337); //Logger 404 som en error.
                        Console.WriteLine("Error 404: File not found.");
                        fs.CopyTo(sw.BaseStream); //Kopierer indholdet ovenover til streamwriteren, som så flusher.
                        sw.BaseStream.Flush();
                        sw.Flush();

            Close();
    }

        /// <summary>
        /// Lukker serveren.
        /// </summary>
        private void Close()
        {
            log.WriteToLog("Server Shutdown", EventLogEntryType.Information, 1337);//Serveren blev slukket
            ns.Close();
            connectionSocket.Close();
            serverSocket.Stop();
            sw.Close();
            sr.Close();
        }
    }

}
    

