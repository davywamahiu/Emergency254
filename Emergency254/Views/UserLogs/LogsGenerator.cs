using System;
using System.Collections.Generic;
using System.Text;

namespace Emergency254.Views.UserLogs
{
    public static class LogsGenerator
    {
        public static List<MyLogs> LogsGenerated()
        {
            return new List<MyLogs>()
            {
                //new MyLogs {Id = "1", CountLogs = "1", Logs="Latitude: 0.243563333, Longitude: 36.0354656320"},
                //new MyLogs {Id = "1", CountLogs = "1", Logs="Latitude: 0.243563333, Longitude: 36.0354656320"},
                //new MyLogs {Id = "1", CountLogs = "1", Logs="Latitude: 0.243563333, Longitude: 36.0354656320"},
                //new MyLogs {Id = "1", CountLogs = "1", Logs="Latitude: 0.243563333, Longitude: 36.0354656320"},
                new MyLogs {Id = "1", CountLogs = $"{DateTime.Now.ToString()}", Logs="Latitude: Unavailable, Longitude: Unavailable"}
            };
        }
    }
}
