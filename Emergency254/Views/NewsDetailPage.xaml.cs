using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Emergency254.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsDetailPage : ContentPage
    {
        public NewsDetailPage()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
                IconImageSource = new FileImageSource { File = "post.png" };
        }
    }
}