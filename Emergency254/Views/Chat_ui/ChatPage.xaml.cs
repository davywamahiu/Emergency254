using Emergency254.Helpers;
using Emergency254.Models;
using Emergency254.Services;
using Plugin.Geolocator;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace Emergency254.Views
{
	public partial class ChatPage : ContentPage
	{
		public ChatPage()
		{
			InitializeComponent();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
			if (string.IsNullOrEmpty(txt_Message.Text))
			{
				txt_Message.TextColor = Color.Red;
				txt_Message.Text = "empty Message/Hakuna Ujumbe";
			}
			var local = await CrossGeolocator.Current.GetPositionAsync(TimeSpan.FromMilliseconds(10000));
			var map = $"https://maps.googleapis.com/maps/api/staticmap?center={local.Latitude.ToString(CultureInfo.InvariantCulture)},{local.Longitude.ToString(CultureInfo.InvariantCulture)}&zoom=17&size=400x400&maptype=street&markers=color:red%7Clabel:%7C{local.Latitude.ToString(CultureInfo.InvariantCulture)},{local.Longitude.ToString(CultureInfo.InvariantCulture)}&key=AIzaSyBUDZZBYLaRbsy9QbNRCorBAGLUHZIrOHM";

			await App.Current.MainPage.DisplayAlert("Sms national diasaster operations center", "Sms us at 364734, it is free no charges applied", "Send", "Cancel");
			var SendUsMessage = CrossMessaging.Current.SmsMessenger;
			if (SendUsMessage.CanSendSms)
			{
				SendUsMessage.SendSms("0726683199", txt_Message.Text + "\n"+ map);
				txt_Message.Text = "";
			}
		}
    }
}