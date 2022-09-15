using CommonServiceLocator;

using Emergency254.Services;
using Emergency254.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Emergency254.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsOverviewPage : ContentPage
    {
        protected NewsViewModel ViewModel => BindingContext as NewsViewModel;
        public NewsOverviewPage()
        {
            InitializeComponent();

            BindingContext = ServiceLocator.Current.GetInstance<NewsViewModel>();
        }
        /*protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Update the list if needed. View Model handles this logic.
            await ViewModel.ExecuteLoadCommand();
        }*/
    }
}