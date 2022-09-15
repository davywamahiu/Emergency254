using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Emergency254.Helpers;
using Emergency254.Models;
using Emergency254.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace Emergency254.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        public AsyncCommand GoToSettingsCommand { get; set; }
        public List<SocialItem> SocialItems { get; }

        public AboutViewModel()
        {
            SocialItems = new List<SocialItem>
            {
                new SocialItem
                {
                    Icon = IconConstants.TwitterCircle,
                    Url = "https://www.twitter.com/ndoc"
                },
                new SocialItem
                {
                    Icon = IconConstants.FacebookBox,
                    Url = "https://www.facebook.com/ndoc"
                },
                new SocialItem
                {
                    Icon = IconConstants.Instagram,
                    Url = "https://www.instagram.com/ndoc"
                }
            };

            GoToSettingsCommand = new AsyncCommand(() => Application.Current.MainPage.Navigation.PushModalAsync(new SettingsPage()));
        }
        



        
    }
}
