using Emergency254.Models;
using Emergency254.ViewModels;

using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;

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
	public partial class ItemsDetailPage : ContentPage
	{
        ItemsDetailViewModel viewModel;

        public ItemsDetailPage(ItemsDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemsDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description.",
                Icon = "",
                FirstAid = "",
                Sub1 = ""
            };

            viewModel = new ItemsDetailViewModel(item);
            BindingContext = viewModel;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Page1());
        }
    }
}