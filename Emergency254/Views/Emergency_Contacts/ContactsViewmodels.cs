using Emergency254.Extensions;
using Emergency254.Utils;
using Emergency254.ViewModels;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Plugin.Geolocator;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Emergency254.Views.Emergency_Contacts
{
    public class ContactsViewmodels : ViewModelBase
    {
        SaveContacts<BeginSavingContact> dataSource2;
        public SaveContacts<BeginSavingContact> DataSource2 =>
            dataSource2 = dataSource2 ?? DependencyService.Get<SaveContacts<BeginSavingContact>>();
        public DateTime LastUpdate { get; set; }
        public ContactsViewmodels()
        {
            BeginSavingContact1 = new BeginSavingContact();
            isNew = true;
            Title = "Add An Emergency Contact";
        }
        readonly bool isNew;

        AsyncCommand saveCommand;

        public AsyncCommand SaveCommand => saveCommand ?? (saveCommand = new AsyncCommand(async () => await ExecuteSaveCommand()));

        public async Task ExecuteSaveCommand()
        {
            if (string.IsNullOrWhiteSpace(BeginSavingContact1.CountLogs) || string.IsNullOrWhiteSpace(BeginSavingContact1.Logs)
                || string.IsNullOrWhiteSpace(BeginSavingContact1.DataPartitionId) || string.IsNullOrWhiteSpace(BeginSavingContact1.Id))
            {
                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Invalid data!",
                    Message = "Your Contacts do not meet required format or length,.",
                    Cancel = "OK"
                });
                return;
            }

            if (isNew)
            {
                await DataSource2.AddItem(BeginSavingContact1);
            }
            else
            {
                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Something is wrong!",
                    Message = "Your Contacts could not be saved.",
                    Cancel = "OK"
                });
            }
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
        AsyncCommand newCommand;
        public AsyncCommand NewCommand => newCommand = newCommand ??
            new AsyncCommand(ExecuteNewCommand);
        Task ExecuteNewCommand() => PushAsync(new AddNewContact());

        AsyncCommand<string> dialNumberCommand;

        public AsyncCommand<string> DialNumberCommand =>
            dialNumberCommand = dialNumberCommand ?? new AsyncCommand<string>(ExecuteDialNumberCommand);

        async Task ExecuteDialNumberCommand(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return;

            try
            {
                PhoneDialer.Open(number.SanitizePhoneNumber());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Not Supported",
                    Message = "Phone calls are not supported on this device.",
                    Cancel = "OK"
                });
            }

        }

        AsyncCommand<string> messageNumberCommand;

        public AsyncCommand<string> MessageNumberCommand =>
            messageNumberCommand = messageNumberCommand ?? new AsyncCommand<string>(ExecuteMessageNumberCommand);

        async Task ExecuteMessageNumberCommand(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return;

            try
            {
                await Sms.ComposeAsync(new SmsMessage(string.Empty, number.SanitizePhoneNumber()));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Not Supported",
                    Message = "Sms is not supported on this device.",
                    Cancel = "OK"
                });
            }
        }

        AsyncCommand loadCommand;
        public AsyncCommand LoadCommand => loadCommand = loadCommand ??
            new AsyncCommand(ExecuteContactLoadCommand);
        public BeginSavingContact BeginSavingContact1 { private set; get; }

        public async Task ExecuteContactLoadCommand()
        {
            if (MyContactz.Count < 1 || LastUpdate < Util.Settings.LastUpdate)
                await FetchUserContactTracker();
        }
        AsyncCommand refreshCommand;
        public AsyncCommand RefreshCommand => refreshCommand = refreshCommand ??
            new AsyncCommand(ExecuteContactRefreshCommand);

        async Task ExecuteContactRefreshCommand()
        {
            await FetchUserContactTracker();
        }

        async Task FetchUserContactTracker()
        {

            await Task.Delay(1000);
            var items = await DataSource2.GetItems();
            if (items.Count() == 0)
            {
                await Dialogs.Question(new QuestionInfo
                {
                    Title = string.Format("There is no data currently."),
                    Question = null,
                    Positive = "Ok",
                    OnCompleted = new Action<bool>(result =>
                    {
                        if (!result)
                            return;
                    })
                });
            }
            else
            {
                MyContactz.ReplaceRange(items);


                LastUpdate = DateTime.UtcNow;

                IsBusy = false;

            }

        }
        public ObservableRangeCollection<BeginSavingContact> MyContactz { get; } = new ObservableRangeCollection<BeginSavingContact>();

        public async void SearchLogs()
        {
            var itemz = await DataSource2.GetItem(SearchTermz);
            MyContactz.ReplaceRange(itemz);
            //GroupContacts();
        }
        public string SearchTermz { get; set; }

    }
}
