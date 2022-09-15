using System;
using System.Collections.Generic;
using System.Text;

namespace Emergency254.Views.UserLogs
{
    public interface IMyLogs
    {
        string DataPartitionId { get; set; }
        string Logs { get; set; }
        string CountLogs { get; set; }
    }
}
