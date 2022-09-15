using Emergency254.BurgainRoad;
using Emergency254.Interfaces;
using Emergency254.Shared.Interfaces;
using Emergency254.Shared.Models;
using Emergency254.ViewModels;

using Shiny;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Emergency254.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage 
    {
        //public Contact Contact { private set; get; }
        protected ListViewModel ViewModel => BindingContext as ListViewModel;

        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ListViewModel();
            
        }

        async void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is Contact a))
                return;

            await Navigation.PushAsync(new UserDetails(a));

            ((ListView)sender).SelectedItem = null;
        }
        void ItemTapped(object sender, ItemTappedEventArgs e) =>
            ((ListView)sender).SelectedItem = null;


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Update the list if needed. View Model handles this logic.
            await ViewModel.ExecuteLoadCommand();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Sets up the map.
        /// </summary>
        /// <returns>A Task.</returns>

    }
}