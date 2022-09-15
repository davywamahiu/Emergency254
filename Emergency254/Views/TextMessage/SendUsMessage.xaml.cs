using Plugin.Geolocator;
using Plugin.Messaging;

using Rg.Plugins.Popup.Services;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Emergency254.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SendUsMessage : ContentPage
	{
		public SendUsMessage ()
		{
			InitializeComponent ();
		}
       
        private void Button_Clicked(object sender, EventArgs e)
        {
			PopupNavigation.Instance.PushAsync(new Page1());
        }
    }
}