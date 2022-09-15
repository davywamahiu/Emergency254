using Emergency254.Interfaces;
using Emergency254.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Emergency254.Views.UserLogs
{
    public class DataLogs : IDataSave<MyLogs>
    {
        bool isInitialized;
        List<MyLogs> UserLogsTracker;
        readonly string fullPath;
        public DataLogs()
        {
            var fileName = "MyLogs.json";
            fullPath = Path.Combine(FileSystem.AppDataDirectory, fileName);
        }
        #region IDataSource implementation
        public async Task<IEnumerable<MyLogs>> GetItem(string id)
        {
            await EnsureInitialized().ConfigureAwait(false);

            return await Task.FromResult(UserLogsTracker.OrderByDescending(x => x.CountLogs.Contains(id))).ConfigureAwait(false);
        }
        public async Task<IEnumerable<MyLogs>> GetItems()
        {
            await EnsureInitialized().ConfigureAwait(false);

            return await Task.FromResult(UserLogsTracker.OrderByDescending(x => x.CountLogs)).ConfigureAwait(false);
        }
        public Task<bool> AddItem(MyLogs itemz)
        {
            UserLogsTracker.Add(itemz);
            WriteFile();


            return Task.FromResult(true);
        }
        async Task WriteFile()
        {
            var contents = System.Text.Json.JsonSerializer.Serialize(UserLogsTracker);
            File.WriteAllText(fullPath, contents);
            Emergency254.Util.Settings.LastUpdate = DateTime.UtcNow;
        }
        #endregion
        protected LogsViewModel ViewModel = new LogsViewModel();
        #region supporting methods

        void Initialize()
        {
            var contents = string.Empty;
            if (File.Exists(fullPath))
            {
                contents = File.ReadAllText(fullPath);
            }

            if (string.IsNullOrWhiteSpace(contents))
            {
                UserLogsTracker = LogsGenerator.LogsGenerated();
                File.WriteAllText(fullPath, contents);
            }
            else
            {
                UserLogsTracker = JsonConvert.DeserializeObject<List<MyLogs>>(contents);
            }

            isInitialized = true;
        }

        Task EnsureInitialized()
        {
            if (!isInitialized)
                return Task.Run(() => Initialize());

            return Task.CompletedTask;
        }

        #endregion
    }
}
