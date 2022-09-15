using System;
using System.Collections.Generic;
using System.Text;

namespace Emergency254.Views.Emergency_Contacts
{
    public static class ContaExtensions
    {
        public static BeginSavingContact Clone(this BeginSavingContact o) =>
           new BeginSavingContact
           {
               Logs = o.Logs,
               CountLogs = o.CountLogs,
               Id = o.Id,
               DataPartitionId = o.DataPartitionId,
           };
        public static void CopyData(this BeginSavingContact o, BeginSavingContact copyInto)
        {
            copyInto.Logs = o.Logs;
            copyInto.CountLogs = o.CountLogs;
            copyInto.DataPartitionId = o.DataPartitionId;
        }
    }
}
