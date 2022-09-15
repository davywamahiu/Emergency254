using System;
using System.Collections.Generic;
using System.Text;

namespace Emergency254.Views.UserLogs
{
    public static class UserExtensionLogs
    {
        public static MyLogs Clone(this MyLogs o) =>
           new MyLogs
           {
               Logs = o.Logs,
               CountLogs = o.CountLogs,
               Id = o.Id,
               DataPartitionId = o.DataPartitionId,
           };
        public static void CopyData(this MyLogs o, MyLogs copyInto)
        {
            copyInto.Logs = o.Logs;
            copyInto.CountLogs = o.CountLogs;
            copyInto.DataPartitionId = o.DataPartitionId;
        }
    }
}
