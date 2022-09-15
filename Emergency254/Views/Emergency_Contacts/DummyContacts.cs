using System;
using System.Collections.Generic;
using System.Text;

namespace Emergency254.Views.Emergency_Contacts
{
    public static class DummyContacts
    {
        public static List<BeginSavingContact> DummContacts()
        {
            return new List<BeginSavingContact>()
            {
                //new MyLogs {Id = "1", CountLogs = "1", Logs="Latitude: 0.243563333, Longitude: 36.0354656320"},
                //new MyLogs {Id = "1", CountLogs = "1", Logs="Latitude: 0.243563333, Longitude: 36.0354656320"},
                //new MyLogs {Id = "1", CountLogs = "1", Logs="Latitude: 0.243563333, Longitude: 36.0354656320"},
                //new MyLogs {Id = "1", CountLogs = "1", Logs="Latitude: 0.243563333, Longitude: 36.0354656320"},
                new BeginSavingContact {Id = "1", CountLogs = "Nakuru County", Logs="County Ambulance: 0739-329-765, St Johns': 0739-834-765"}
            };
        }
    }
}
