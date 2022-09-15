using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Emergency254.Services;
using Emergency254.Views;
using Emergency254.Init;
using System.Collections.Generic;
using Emergency254.Styles;
using Emergency254.Util;
using Emergency254.Views.UserLogs;
using System.Threading.Tasks;
using Emergency254.Views.Emergency_Contacts;

namespace Emergency254
{
    public partial class App : Application
    {
        public static bool UseLocalDataSource = true;
        public enum AppState
        {
            Foreground,
            Background
        }
        public App()
        {
            Xamarin.Forms.Device.SetFlags(new List<string>() {
                    "StateTriggers_Experimental",
                    "IndicatorView_Experimental",
                    "CarouselView_Experimental",
                    "MediaElement_Experimental"
                });
            InitializeComponent();
            //CallLocationhere();
            Bootstrapper.RegisterDependencies();
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<DataLogs>();
            DependencyService.Register<ContactsLogs>();
            MainPage = new AppShell();
            if (UseLocalDataSource)
                DependencyService.Register<FileDataSource>();
            else
                return;
        }
        //public async Task CallLocationhere()
        //{
        //    LogsViewModel logsViewModel = new LogsViewModel();
        //    await logsViewModel.ExeCuteLogsCommand();
        //    await Task.Delay(1000);
        //    await CallMe();
        //}
        //public async Task CallMe()
        //{
        //    //await Task.Delay(4000);
        //    //await CallLocationhere();
        //}
        protected async override void OnStart()
        {
            base.OnStart();
            ThemeHelper.ChangeTheme(Settings.ThemeOption, true);
            //await Task.Delay(4000);
            //await CallLocationhere();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnResume();
            ThemeHelper.ChangeTheme(Settings.ThemeOption, true);
        }
    }
}
