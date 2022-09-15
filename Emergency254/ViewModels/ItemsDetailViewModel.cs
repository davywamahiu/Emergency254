using Emergency254.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emergency254.ViewModels
{
    public class ItemsDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemsDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
