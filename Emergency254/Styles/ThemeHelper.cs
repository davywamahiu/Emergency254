using Emergency254.Helpers;
using Emergency254.Interfaces;
using Emergency254.Models;

using SmartFirm.DashBoards.Styles;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Emergency254.Styles
{
    public static class ThemeHelper
    {
        public static Theme CurrentTheme = Settings.ThemeOption;

        public static void ChangeTheme(Theme theme, bool forceTheme = false)
        {
            // don't change to the same theme
            if (theme == CurrentTheme && !forceTheme)
                return;

            //// clear all the resources
            var applicationResourceDictionary = Application.Current.Resources;
            ResourceDictionary newTheme;
            if (theme == Theme.Default)            {
                
                theme = AppInfo.RequestedTheme == AppTheme.Dark ? Theme.Dark : Theme.Light;
            }

            switch (theme)
            {
                case Theme.Light:
                    newTheme = new LightTheme();
                    break;
                case Theme.Dark:
                    newTheme = new DarkTheme();
                    break;
                case Theme.Default:
                default:
                    newTheme = new LightTheme();
                    break;
            }

            ManuallyCopyThemes(newTheme, applicationResourceDictionary);

            CurrentTheme = theme;

            var background = (Color)App.Current.Resources["WindowBackgroundColor"];

            var environment = DependencyService.Get<IEnvironment>(); 
            environment?.SetStatusBarColor(background, theme != Theme.Dark);
        }

        static void ManuallyCopyThemes(ResourceDictionary fromResource, ResourceDictionary toResource)
        {
            foreach (var item in fromResource.Keys)
            {
                toResource[item] = fromResource[item];
            }
        }
    }
}
