using Emergency254.Shared.Interfaces;
using Emergency254.Shared.Models;
using Emergency254.Views.UserLogs;

using System;
using System.Collections.Generic;
using System.Text;

namespace Emergency254.ViewModels
{
    public class ItemsDetailPage1 : ViewModelBase
    {
        public MyLogs Item { get; set; }
        public ItemsDetailPage1(MyLogs item = null)
        {
            Title = item?.CountLogs;
            Item = item;
        }
    }
}
