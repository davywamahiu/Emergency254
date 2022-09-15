using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Emergency254.Views.Emergency_Contacts
{
    public class ContactsLogs : SaveContacts<BeginSavingContact>
    {
        bool isInitialized;
        List<BeginSavingContact> MyContactzz;
        readonly string fullPath;
        public ContactsLogs()
        {
            var fileName = "BeginSavingContact.json";
            fullPath = Path.Combine(FileSystem.AppDataDirectory, fileName);
        }
        #region IDataSource implementation
        public async Task<IEnumerable<BeginSavingContact>> GetItem(string id)
        {
            await EnsureInitialized().ConfigureAwait(false);

            return await Task.FromResult(MyContactzz.OrderByDescending(x => x.CountLogs.Contains(id))).ConfigureAwait(false);
        }
        public async Task<IEnumerable<BeginSavingContact>> GetItems()
        {
            await EnsureInitialized().ConfigureAwait(false);

            return await Task.FromResult(MyContactzz.OrderBy(x => x.CountLogs)).ConfigureAwait(false);
        }
        public async Task<bool> AddItem(BeginSavingContact items)
        {
            await EnsureInitialized().ConfigureAwait(false);
            MyContactzz.Add(items);
            WriteFile();

            return await Task.FromResult(true);
        }
        void WriteFile()
        {
            var contents = JsonConvert.SerializeObject(MyContactzz);
            File.WriteAllText(fullPath, contents);
            Emergency254.Util.Settings.LastUpdate = DateTime.UtcNow;
        }
        #endregion
        protected ContactsViewmodels ViewModel = new ContactsViewmodels();
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
                MyContactzz = DummyContacts.DummContacts();
                File.WriteAllText(fullPath, contents);
            }
            else
            {
                MyContactzz = JsonConvert.DeserializeObject<List<BeginSavingContact>>(contents);
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
