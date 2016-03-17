using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace LMS.Web.ExceptionHandling
{
    public static class TraceLog
    {
        //TODO to be optimised
        public static void Create(string error)
        {
            var appLog = new System.Diagnostics.EventLog();
            appLog.Source = "Pressford.News";
            appLog.WriteEntry(error, EventLogEntryType.Error);
        }
    }
}