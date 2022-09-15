using Emergency254.Utils;
using Plugin.Geolocator;
using Plugin.Messaging;

using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
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
    public partial class Page1 : PopupPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
            await Dialogs.Question(new QuestionInfo
            {
                Title = string.Format("Read on how to give best response."),
                Question = null,
                Positive = "Read?",
                Negative = "Cancel",
                OnCompleted = new Action<bool>(async result =>
                {
                    if (!result)
                        return;
                    else
                    {
                        await App.Current.MainPage.Navigation.PushAsync(new SendUsMessage());
                    }

                })
            });
            
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
            await Dialogs.Question(new QuestionInfo
            {
                Title = string.Format("Call NDOC."),
                Question = null,
                Positive = "Call",
                Negative = "Cancel",
                OnCompleted = new Action<bool>(result =>
                {
                    if (!result)
                        return;
                    else
                    {
                        var CallUs = CrossMessaging.Current.PhoneDialer;
                        if (CallUs.CanMakePhoneCall)
                        {
                            CallUs.MakePhoneCall("0726683199", "National disaster");
                        }
                    }

                })
            });
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
            await Dialogs.Question(new QuestionInfo
            {
                Title = string.Format("Send Message."),
                Question = null,
                Positive = "Send",
                Negative = "Cancel",
                OnCompleted = new Action<bool>(async result =>
                {
                    if (!result)
                        return;

                    await App.Current.MainPage.Navigation.PushAsync(new ChatPage());
                })
            });
            
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
            
            await Dialogs.Question(new QuestionInfo
            {
                Title = string.Format("Email national diasaster operations center, "+"Email us at disasterMgmt@go.ke"),
                Question = null,
                Positive = "Send",
                Negative = "Cancel",
                OnCompleted = new Action<bool>(async result =>
                {
                    if (!result)
                        return;
                    var local = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
                    var map = $"https://maps.googleapis.com/maps/api/staticmap?center={local.Latitude.ToString(CultureInfo.InvariantCulture)},{local.Longitude.ToString(CultureInfo.InvariantCulture)}&zoom=17&size=400x400&maptype=street&markers=color:red%7Clabel:%7C{local.Latitude.ToString(CultureInfo.InvariantCulture)},{local.Longitude.ToString(CultureInfo.InvariantCulture)}&key=AIzaSyBUDZZBYLaRbsy9QbNRCorBAGLUHZIrOHM";
                    var SendUsEmail = CrossMessaging.Current.EmailMessenger;
                    if (SendUsEmail.CanSendEmail)
                    {
                        SendUsEmail.SendEmail("davywamahiu1@gmail.com", $"{map}");
                    }
                })
            });
            
        }
    }
}