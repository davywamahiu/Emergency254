using System.Collections.ObjectModel;
using Emergency254.Helpers;
using Emergency254.Models;
using Emergency254.Styles;
using Xamarin.Forms;

namespace Emergency254.ViewModels
{
    public class SettingsViewModel1 : ViewModelBase
    {
        public ObservableCollection<string> ThemeOptions { get; } = new ObservableCollection<string>();
        public SettingsViewModel1()
        {
            ThemeOptions.Add("Light");
            ThemeOptions.Add("Dark");

            if (DesignMode.IsDesignModeEnabled)
                return;


            if(Settings.HasDefaultThemeOption)
                ThemeOptions.Insert(0, "Device Default");
            

            if (ThemeOptions.Count == 3)
                SelectedTheme = (int)Settings.ThemeOption;
            else
                SelectedTheme = (int)Settings.ThemeOption - 1;
        }

        int selectedTheme;
        public int SelectedTheme
        {
            get => selectedTheme;
            set
            {
                if (SetProperty(ref selectedTheme, value))
                {
                    if (ThemeOptions.Count == 3)
                        Settings.ThemeOption = (Theme)value;
                    else
                        Settings.ThemeOption = (Theme)(value + 1);

                    ThemeHelper.ChangeTheme(Settings.ThemeOption, true);
                }
            }
        }
    }
}
