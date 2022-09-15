using System;
using System.Collections.Generic;

using Emergency254.ViewModels;
using Emergency254.Views;

using Xamarin.Forms;

namespace Emergency254
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemsDetailPage), typeof(ItemsDetailPage));
        }

    }
}
