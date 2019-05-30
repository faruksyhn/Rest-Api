using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtoKiralama.Commons.Abstractions;

namespace OtoKiralama.Commons.Concretes.Loggers
{
    internal class EventLogger : LogBase
    {

        public override void Log(string message, bool isError)
        {
            lock (lockObj)
            {
                EventLog m_EventLog = new EventLog();
                m_EventLog.Source = "OtoKiralamaEventLog";
                m_EventLog.WriteEntry(message);
            }
        }
    }
}
