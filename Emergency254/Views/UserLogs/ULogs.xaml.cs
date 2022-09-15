using Emergency254.Styles;
using Emergency254.Views.UserLogs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Emergency254.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ULogs : ContentPage
    {
        protected LogsViewModel ViewModel => BindingContext as LogsViewModel;

        public ULogs()
        {
            InitializeComponent();
            BindingContext = new LogsViewModel();
        }

        /*async void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is MyLogs a))
                return;

            await Navigation.PushAsync(new DetailPage(a));

            ((ListView)sender).SelectedItem = null;
        }
        void ItemTapped(object sender, ItemTappedEventArgs e) =>
            ((ListView)sender).SelectedItem = null;*/
        public string DateLogs;
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.ExecuteLoadCommand();
            //Update the list if needed. View Model handles this logic.
            DateLogs =  DateTime.Now.ToString();
            
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ViewModel.SearchLogs();
        }
    }
}