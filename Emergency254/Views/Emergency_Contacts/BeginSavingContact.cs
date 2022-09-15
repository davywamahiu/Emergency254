using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MvvmHelpers;
using System.Text.Json.Serialization;

namespace Emergency254.Views.Emergency_Contacts
{
    public class BeginSavingContact : ObservableObject, SaveContacts
    {
        public string DataPartitionId { get; set; } = string.Empty;
        [JsonIgnore]
        public bool isGroupFirst { get; set; }
        string id = string.Empty;
        [JsonPropertyName("id")]
        public string Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        string logs = string.Empty;
        [JsonPropertyName("logs")]
        public string Logs
        {
            get => logs;
            set => SetProperty(ref logs, value);
        }
        string countlogs = string.Empty;
        [JsonPropertyName("countlogs")]
        public string CountLogs
        {
            get => countlogs;
            set => SetProperty(ref countlogs, value);
        }
    }
}
