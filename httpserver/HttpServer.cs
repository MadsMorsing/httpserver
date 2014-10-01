using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace httpserver
{
    public class HttpServer
    {
        public static readonly int DefaultPort = 8080;


        #region 

//// Setting default values
//        public static readonly int DefaultPort = 8080;
//        public static readonly IPAddress DefaultIp = IPAddress.Parse("127.0.0.1");
//        public static string root = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

//        // Case return, line feed
//        private string CRLF = "\r\n";

//        // Declare variables
//        private string firstline;
//        private TcpListener serverSocket;
//        private TcpClient connectionSocket;
//        private NetworkStream ns;
//        private StreamWriter sw;
//        private StreamReader sr;
//        private FileStream source = null;

//        /// <summary>
//        /// HttpServer Constructor.
//        /// Listen for TCP connections.
//        /// </summary>
//        public HttpServer()
//        {
//            serverSocket = new TcpListener(DefaultIp, DefaultPort);
//            serverSocket.Start();
//        }

//        /// <summary>
//        /// Wait for client to connect.
//        /// </summary>
//        public void WaitForClient()
//        {
//            connectionSocket = serverSocket.AcceptTcpClient();
//            ns = connectionSocket.GetStream();
//            GetRequest();
//        }

//        /// <summary>
//        /// Get client request.
//        /// </summary>
//        private void GetRequest()
//        {
//            sr = new StreamReader(ns);
//            firstline = sr.ReadLine();
//            SetResponse();
//        }

//        /// <summary>
//        /// Set client response.
//        /// </summary>
//        private void SetResponse()
//        {
//            if (firstline != null)
//            {
//                Console.WriteLine();
//                Console.WriteLine(firstline);

//                char[] charSeparators = new char[] {' '};
//                string[] split = firstline.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

//                try
//                {
//                    source = File.Open("C:\\Users\\Johan\\Desktop\\Textfiles.htm", FileMode.Open);
//                    Console.WriteLine("test");
//                }
//                catch (FileNotFoundException e)
//                {
//                    Console.WriteLine(e);
//                }
//                catch (DirectoryNotFoundException e)
//                {
//                    Console.WriteLine(e);
//                }

//                HttpResponse();
//            }
//            else
//            {
//                Console.WriteLine("Empty request.");
//            }
//        }

//        /// <summary>
//        /// Send response to the client.
//        /// </summary>
//        private void HttpResponse()
//        {
//            sw = new StreamWriter(ns, Encoding.UTF8);
//            sw.AutoFlush = true;
//            sw.Write("HTTP/1.0 200 OK\r\n");
//            sw.Write("Content-Type: text/html\r\n");
//            sw.Write("\r\n");
//            if (source != null)
//            {
//                source.CopyTo(ns);
//                source = null;
//            }

//            CloseAll();
//        }

//        /// <summary>
//        /// Close connections.
//        /// </summary>
//        private void CloseAll()
//        {
//            if (source != null)
//            {
//                source.Close();
//            }
//            sw.Close();
//            sr.Close();
//            ns.Close();
//            connectionSocket.Close();
//        }

//        /// <summary>
//        /// Close server.
//        /// </summary>
//        public void CloseServer()
//        {
//            serverSocket.Stop();
//        }

        #endregion

    }
}
