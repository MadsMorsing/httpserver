using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace httpserver
{
    class Logger
    {
        private const string Source = "HttpServer";
        private const string sLog = "Application";
        private const string Message = "Event occur";
        public void start()
        {

            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, sLog);
            }

            WriteToLog("", EventLogEntryType.Information, 1337);

        }

        public void WriteToLog(string s, EventLogEntryType info, int num )
        {

            if (!EventLog.SourceExists(Source))
            {
                EventLog.CreateEventSource(Source, sLog);
            }

            string machineName = ".";
            using (EventLog log = new EventLog(sLog, machineName, Source))
            {
                log.WriteEntry(s, info, num);
            }
        }
    }
}
