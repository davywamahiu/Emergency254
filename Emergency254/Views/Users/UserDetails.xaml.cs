using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
using System;
using Emergency254.ViewModels;
using Xamarin.Essentials;
using System.Linq;
using Emergency254.Models;
using Emergency254.Shared.Models;
using Rg.Plugins.Popup.Services;
using Emergency254.Extensions;
using Emergency254.Utils;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Emergency254.Views
{
    public partial class UserDetails : ContentPage
    {
        
        protected DetailViewModel ViewModel => BindingContext as DetailViewModel;
        readonly string fullPath;
        List<CovTrack> covTrack;
        public UserDetails()
        {
            InitializeComponent();
            var fileName = "Locationlogs.json";
            fullPath = Path.Combine(FileSystem.AppDataDirectory, fileName);
        }

        public UserDetails(Contact MyContacts)
        {
            InitializeComponent();
            BindingContext = new DetailViewModel(MyContacts);
            if (verify_me.Text.IsNullOrWhiteSpace())
            {
                verify_me.IsEnabled = true;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }
        public Task<bool> AddItem(CovTrack item)
        {
            covTrack.Add(item);
            Console.WriteLine($"Written successfully: {item}");
            WriteFile();


            return Task.FromResult(true);
        }
        void WriteFile()
        {
            var contents = JsonConvert.SerializeObject(covTrack);
            File.WriteAllText(fullPath, contents);
            Emergency254.Util.Settings.LastUpdate = DateTime.UtcNow;
        }
        async void OpenEasterEgg(object sender, System.EventArgs e)
        {
            ImgMorning.IsVisible = true;
            ImgMorning.Opacity = 0;
            await ImgMorning.FadeTo(1, 2000, Easing.Linear);
        }
        async void HideEasterEgg(object sender, System.EventArgs e)
        {
            await ImgMorning.ScaleTo(5, 300, Easing.CubicIn);
            ImgMorning.IsVisible = false;
            ImgMorning.Scale = 1;
        }
        /// <summary>
        /// Sets up the map.
        /// </summary>
        /// <returns>A Task.</returns>
        

        private void Button_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Page1());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            longi.Text = "";
            lati.Text = "";
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            
            try
            {
                var locatione = await Geolocation.GetLastKnownLocationAsync();
                if (locatione == null)
                {
                    locatione = await Geolocation.GetLocationAsync(new GeolocationRequest()
                    {
                        DesiredAccuracy = GeolocationAccuracy.Best,
                        Timeout = TimeSpan.FromMinutes(5)
                    });
                }
                if (locatione == null)
                {
                    lati.Text = "Latitude absent";
                    longi.Text = "Longitude absent";
                }
                else
                {
                    var xfpos = new Position(locatione.Latitude, locatione.Longitude);
                    lati.Text = $"{locatione.Latitude}";
                    longi.Text = $"{locatione.Longitude}";
                    locame.MoveToRegion(MapSpan.FromCenterAndRadius(xfpos, Distance.FromMeters(20)));
                    
                    var locations = await Geocoding.GetPlacemarksAsync(locatione);
                    var mylogs = $"Latitude: {locatione.Latitude}, Longitude: {locatione.Longitude}, Place: {locations}";
                    locame.IsVisible = true;
                    Debug.WriteLine($"Here we are: {locations}");
                    CovTrack makingthings = new CovTrack
                    {
                        Logs = mylogs
                    };
                    await AddItem(makingthings);
                    Debug.Write($"Here we are: {makingthings}");
                }
            }
            catch (Exception ex)
            {

                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Ooops, Something is wrong!",
                    Message = $"Unable to get your location reason: {ex.Message}",
                    Cancel = "OK"
                });
                return;
            }
        }
    }
    public class Makingthings
    {
        public string Mjei { get; set; }
    }
}
