
using Emergency254.ViewModels;

using Xamarin.Essentials;
using Xamarin.Forms;

//mjfreelanding cheered 100 bits on December 10th 2019

namespace Emergency254.Views
{
    public partial class AboutPage : ContentPage
    {
        AboutViewModel vm;
        AboutViewModel VM => vm = vm?? BindingContext as AboutViewModel;

        public AboutPage()
        {
            InitializeComponent();
            BindingContext = new AboutViewModel();
            var dname = DeviceInfo.Name;
            var osversion = DeviceInfo.VersionString;
            var platform = DeviceInfo.Platform;
            var dtype = DeviceInfo.DeviceType;
            if(osversion.Contains("5.0") || osversion.Contains("5.1") || osversion.Contains("6.0") ||
                osversion.Contains("6.1") || osversion.Contains("7.0") || osversion.Contains("7.1") ||
                osversion.Contains("8.0") || osversion.Contains("8.1") || osversion.Contains("9.0") ||
                osversion.Contains("10.0") || osversion.Contains("11.0"))
            {
                string myDeviceIs = dname + ", " + osversion + ", " + platform;
                myDVice.Text = myDeviceIs;
                name_is.Text = "Supports this App: ";
            }
            else
            {
                myDVice.Text = "Your Device is too low to support this app, It will crash constantly";
            }
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
