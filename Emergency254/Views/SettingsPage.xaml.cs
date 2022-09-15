using System;
using System.Linq;

using Emergency254.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Emergency254.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel1();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
#if !DEBUG
            if (Navigation.ModalStack.Any())
                await Navigation.PopModalAsync();
#endif
        }
    }
}