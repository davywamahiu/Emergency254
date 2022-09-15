using Emergency254.Services;
using Emergency254.Utils;
using Emergency254.ViewModels;

using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Emergency254.Views.UserLogs
{
    public class LogsViewModel : ViewModelBase
    {
        IDataSave<MyLogs> dataSource1;
        public IDataSave<MyLogs> DataSource1 =>
            dataSource1 = dataSource1 ?? DependencyService.Get<IDataSave<MyLogs>>();
        public DateTime LastUpdate { get; set; }
        public LogsViewModel()
        {
            Llogs = new MyLogs();
            isNew = true;
        }
        readonly bool isNew;
        public async Task ExeCuteLogsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            await Task.Delay(1000);
            try
            {
                var locatione = await Geolocation.GetLastKnownLocationAsync();
                if (locatione == null)
                {
                    locatione = await Geolocation.GetLocationAsync(new GeolocationRequest()
                    {
                        DesiredAccuracy = GeolocationAccuracy.Best,
                        Timeout = TimeSpan.FromMinutes(5)
                    });
                }
                if (locatione == null)
                {
                    await Dialogs.Alert(new AlertInfo
                    {
                        Title = "Ooops, Something is wrong!",
                        Message = "No cached location",
                        Cancel = "OK"
                    });
                    return;
                }
                if (isNew)
                {
                    var unic = Guid.NewGuid();
                    string GuidString1 = Convert.ToBase64String(unic.ToByteArray());
                    GuidString1 = GuidString1.Replace("=", "");
                    GuidString1 = GuidString1.Replace("+", "");
                    GuidString1 = GuidString1.Replace("/", "");
                    GuidString1 = GuidString1.Replace("A", "");
                    GuidString1 = GuidString1.Replace("B", "");
                    GuidString1 = GuidString1.Replace("C", "");
                    GuidString1 = GuidString1.Replace("D", "");
                    GuidString1 = GuidString1.Replace("E", "");
                    GuidString1 = GuidString1.Replace("F", "");
                    GuidString1 = GuidString1.Replace("G", "");
                    GuidString1 = GuidString1.Replace("H", "");
                    GuidString1 = GuidString1.Replace("I", "");
                    GuidString1 = GuidString1.Replace("J", "");
                    GuidString1 = GuidString1.Replace("K", "");
                    GuidString1 = GuidString1.Replace("L", "");
                    GuidString1 = GuidString1.Replace("M", "");
                    GuidString1 = GuidString1.Replace("N", "");
                    GuidString1 = GuidString1.Replace("O", "");
                    GuidString1 = GuidString1.Replace("P", "");
                    GuidString1 = GuidString1.Replace("Q", "");
                    GuidString1 = GuidString1.Replace("R", "");
                    GuidString1 = GuidString1.Replace("S", "");
                    GuidString1 = GuidString1.Replace("T", "");
                    GuidString1 = GuidString1.Replace("U", "");
                    GuidString1 = GuidString1.Replace("V", "");
                    GuidString1 = GuidString1.Replace("W", "");
                    GuidString1 = GuidString1.Replace("X", "");
                    GuidString1 = GuidString1.Replace("Y", "");
                    GuidString1 = GuidString1.Replace("Z", "");
                    var ucode = Guid.NewGuid();
                    string GuidString2 = Convert.ToBase64String(ucode.ToByteArray());
                    GuidString2 = GuidString2.Replace("=", "");
                    GuidString2 = GuidString2.Replace("+", "");
                    GuidString2 = GuidString2.Replace("/", "");
                    GuidString2 = GuidString2.Replace("a", "");
                    GuidString2 = GuidString2.Replace("b", "");
                    GuidString2 = GuidString2.Replace("c", "");
                    GuidString2 = GuidString2.Replace("d", "");
                    GuidString2 = GuidString2.Replace("c", "");
                    GuidString2 = GuidString2.Replace("d", "");
                    GuidString2 = GuidString2.Replace("f", "");
                    GuidString2 = GuidString2.Replace("g", "");
                    GuidString2 = GuidString2.Replace("h", "");
                    GuidString2 = GuidString2.Replace("e", "");
                    GuidString2 = GuidString2.Replace("i", "");
                    GuidString2 = GuidString2.Replace("j", "");
                    GuidString2 = GuidString2.Replace("k", "");
                    GuidString2 = GuidString2.Replace("m", "");
                    GuidString2 = GuidString2.Replace("o", "");
                    GuidString2 = GuidString2.Replace("n", "");
                    GuidString2 = GuidString2.Replace("p", "");
                    GuidString2 = GuidString2.Replace("q", "");
                    GuidString2 = GuidString2.Replace("r", "");
                    GuidString2 = GuidString2.Replace("s", "");
                    GuidString2 = GuidString2.Replace("t", "");
                    GuidString2 = GuidString2.Replace("u", "");
                    GuidString2 = GuidString2.Replace("v", "");
                    GuidString2 = GuidString2.Replace("w", "");
                    GuidString2 = GuidString2.Replace("x", "");
                    GuidString2 = GuidString2.Replace("y", "");
                    GuidString2 = GuidString2.Replace("z", "");
                    //var xfpos = new Position(locatione.Latitude, locatione.Longitude);
                    string lati = locatione.Latitude.ToString();
                    string longi = locatione.Longitude.ToString();
                    string speedy = locatione.Speed.ToString();
                    //var locations = await Geocoding.GetPlacemarksAsync(locatione);
                    var mylogs = $"Latitude: {lati}, Longitude: {longi}, Speed: {speedy}";
                    
                    if (locatione == null)
                    {
                        Llogs.DataPartitionId = GuidString1;
                        Llogs.Id = GuidString2;
                        Llogs.CountLogs = DateTime.Now.ToString();
                        Llogs.Logs = "Your Location is unavailable, please enable location using the location icon on pull menu";
                        await DataSource1.AddItem(Llogs);
                    }
                    else
                    {
                        Llogs.Logs = mylogs;
                        //var locations = await Geocoding.GetPlacemarksAsync(locatione);

                        Llogs.Id = GuidString2;
                        Llogs.DataPartitionId = GuidString1;
                        Llogs.CountLogs = DateTime.Now.ToString();
                        await DataSource1.AddItem(Llogs);
                    }
                }
                else
                {

                    await Dialogs.Alert(new AlertInfo
                    {
                        Title = "Data saving process!",
                        Message = "Data saved!!!",
                        Cancel = "OK"
                    });
                    return;
                    //locame.IsVisible = true;
                }
                return;
            }
            catch (Exception)
            {

                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Ooops, Something is wrong!",
                    Message = $"Unable to get your location reason: Network error, we will use cached location",
                    Cancel = "OK"
                });
                return;
            }
        }
        public MyLogs Llogs { private set; get;}


        AsyncCommand loadCommand;
        public AsyncCommand LoadCommand => loadCommand = loadCommand ??
            new AsyncCommand(ExecuteLoadCommand);

        public async Task ExecuteLoadCommand()
        {
            if (UserLogsTracker.Count < 1 || LastUpdate < Util.Settings.LastUpdate)
                await FetchUserLogsTracker();
        }
        AsyncCommand refreshCommand;
        public AsyncCommand RefreshCommand => refreshCommand = refreshCommand ??
            new AsyncCommand(ExecuteRefreshCommand);

        async Task ExecuteRefreshCommand()
        {
            await FetchUserLogsTracker();
        }

        async Task FetchUserLogsTracker()
        {

            await Task.Delay(1000);
            var items = await DataSource1.GetItems();
            if (items.Count() == 0)
            {
                await Dialogs.Question(new QuestionInfo
                {
                    Title = string.Format("There is no data currently."),
                    Question = null,
                    Positive = "Ok",
                    Negative = "Cancel",
                    OnCompleted = new Action<bool>(async result =>
                    {
                        if (!result)
                            return;
                        await ExeCuteLogsCommand();
                    })
                });
            }
            else
            {
                 UserLogsTracker.ReplaceRange(items);

                
                LastUpdate = DateTime.UtcNow;

                IsBusy = false;
                
            }

        }
        public ObservableRangeCollection<MyLogs> UserLogsTracker { get; } = new ObservableRangeCollection<MyLogs>();
        
        public MyLogs MyLogs { get; set; }
        public async void SearchLogs()
        {
            var itemz = await DataSource1.GetItem(SearchTerm);
            UserLogsTracker.ReplaceRange(itemz);
            //GroupContacts();
        }
        public string SearchTerm { get; set; }
        
    }
}
