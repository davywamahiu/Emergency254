
using Emergency254.Models;
using Emergency254.ViewModels;
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
	public partial class HelpInEmergency : ContentPage
	{
        ItemsViewModel viewModel;
        public HelpInEmergency ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new ItemsViewModel();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Item item))
                return;

            await Navigation.PushAsync(new ItemsDetailPage(new ItemsDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}