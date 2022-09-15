using System.Threading.Tasks;
using Emergency254.Interfaces;
using Emergency254.Shared.Models;
using MvvmHelpers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Emergency254.Models;
using System.Collections.Generic;

namespace Emergency254.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {
        IDataSource<Contact> dataSource;
        public IDataSource<Contact> DataSource =>
            dataSource = dataSource?? DependencyService.Get<IDataSource<Contact>>();


        protected Page CurrentPage => Application.Current.MainPage;

        protected Task DisplayAlert(string title, string message, string cancel) =>
            CurrentPage.DisplayAlert(title, message, cancel);

        public static Task OpenBrowserAsync(string url) =>
            Browser.OpenAsync(url, new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredControlColor = Color.White,
                PreferredToolbarColor = (Color)Application.Current.Resources["PrimaryColor"]
            });
		INavigation Navigation => Application.Current?.MainPage?.Navigation;

		#region INavigation implementation

		public void RemovePage(Page page)
		{
			Navigation?.RemovePage(page);
		}

		public void InsertPageBefore(Page page, Page before)
		{
			Navigation?.InsertPageBefore(page, before);
		}

		public async Task PushAsync(Page page)
		{
			var task = Navigation?.PushAsync(page);
			if (task != null)
				await task;
		}

		public async Task<Page> PopAsync()
		{
			var task = Navigation?.PopAsync();
			return task != null ? await task : await Task.FromResult(null as Page);
		}

		public async Task PopToRootAsync()
		{
			var task = Navigation?.PopToRootAsync();
			if (task != null)
				await task;
		}

		public async Task PushModalAsync(Page page)
		{
			var task = Navigation?.PushModalAsync(page);
			if (task != null)
				await task;
		}

		public async Task<Page> PopModalAsync()
		{
			var task = Navigation?.PopModalAsync();
			return task != null ? await task : await Task.FromResult(null as Page);
		}

		public async Task PushAsync(Page page, bool animated)
		{
			var task = Navigation?.PushAsync(page, animated);
			if (task != null)
				await task;
		}

		public async Task<Page> PopAsync(bool animated)
		{
			var task = Navigation?.PopAsync(animated);
			return task != null ? await task : await Task.FromResult(null as Page);
		}

		public async Task PopToRootAsync(bool animated)
		{
			var task = Navigation?.PopToRootAsync(animated);
			if (task != null)
				await task;
		}

		public async Task PushModalAsync(Page page, bool animated)
		{
			var task = Navigation?.PushModalAsync(page, animated);
			if (task != null)
				await task;
		}

		public async Task<Page> PopModalAsync(bool animated)
		{
			var task = Navigation?.PopModalAsync(animated);
			return task != null ? await task : await Task.FromResult(null as Page);
		}

		public IReadOnlyList<Page> NavigationStack => Navigation?.NavigationStack;

		public IReadOnlyList<Page> ModalStack => Navigation?.ModalStack;

		#endregion
	}
}
