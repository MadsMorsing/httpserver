using System.Diagnostics;
namespace httpserver
{
    class Logger
    {
        private const string Source = "HttpServer";
        private const string sLog = "Application";
     
        /// <summary>
        /// Skriver info til loggen ud fra de 3 parametre.
        /// </summary>
        /// <param name="message">String - informer om event.</param>
        /// <param name="info">Typen af event.</param>
        /// <param name="num">Loggens ID</param>
        public void WriteToLog(string message, EventLogEntryType info, int num )
        {

            if (!EventLog.SourceExists(Source)) //Hvis der ikke eksisterer en source, laves der en i "Application"
            {
                EventLog.CreateEventSource(Source, sLog);
            }

            string machineName = ".";
            using (EventLog log = new EventLog(sLog, machineName, Source))
            {
                log.WriteEntry(message, info, num);
            }
        }
    }
}
