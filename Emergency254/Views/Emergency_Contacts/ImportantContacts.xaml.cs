using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Emergency254.Views.Emergency_Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImportantContacts : ContentPage
    {
        protected ContactsViewmodels ViewModel => BindingContext as ContactsViewmodels;
        public ImportantContacts()
        {
            InitializeComponent();
            BindingContext = new ContactsViewmodels();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.ExecuteContactLoadCommand();
            //Update the list if needed. View Model handles this logic.

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ViewModel.SearchLogs();
        }
    }
}