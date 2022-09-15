using System;
using System.Threading.Tasks;
using Emergency254.Util;
using Emergency254.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Emergency254.Shared.Models;
using Emergency254.Utils;
using System.Linq;

namespace Emergency254.ViewModels
{
    public class ListViewModel : ContactViewModel
    {
        public DateTime LastUpdate { get; set; }
        public ListViewModel()
        {
        }


        public ObservableRangeCollection<Contact> Contacts { get; } = new ObservableRangeCollection<Contact>();

        AsyncCommand loadCommand;
        public AsyncCommand LoadCommand => loadCommand = loadCommand??
            new AsyncCommand(ExecuteLoadCommand);

        public async Task ExecuteLoadCommand()
        { 
            if (Contacts.Count < 1 || LastUpdate < Settings.LastUpdate)
                await FetchContacts();
        }

        AsyncCommand refreshCommand;
        public AsyncCommand RefreshCommand => refreshCommand = refreshCommand??
            new AsyncCommand(ExecuteRefreshCommand);

        async Task ExecuteRefreshCommand()
        {
            await FetchContacts();
        }

        async Task FetchContacts()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            await Task.Delay(1000);
            var items = await DataSource.GetItems();
            if(items.Count() == 0)
            {
                await Dialogs.Question(new QuestionInfo
                {
                    Title = string.Format("You are not registered yet."),
                    Question = null,
                    Positive = "Register?",
                    Negative = "Not now!",
                    OnCompleted = new Action<bool>(async result =>
                    {
                        if (!result)
                            return;

                        await ExecuteNewCommand();
                    })
                });
            }
            else
            {
                Contacts.ReplaceRange(items);

                LastUpdate = DateTime.UtcNow;

                IsBusy = false;
            }
            
        }

        AsyncCommand newCommand;
        public AsyncCommand NewCommand => newCommand = newCommand??
            new AsyncCommand(ExecuteNewCommand);
        Task ExecuteNewCommand() => PushAsync(new EditPage());

        AsyncCommand showSettingsCommand;
        public AsyncCommand ShowSettingsCommand => showSettingsCommand = showSettingsCommand??
            new AsyncCommand(ExecuteShowSettingsCommand);

        Task ExecuteShowSettingsCommand() => PushModalAsync(new SettingsPage());
    }
}

