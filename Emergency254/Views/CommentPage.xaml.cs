using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Emergency254.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CommentPage : ContentPage
	{
		public CommentPage ()
		{
			InitializeComponent ();

		    if (Device.RuntimePlatform == Device.iOS)
		        Icon = new FileImageSource { File = "comments.png" };
        }
	}
}