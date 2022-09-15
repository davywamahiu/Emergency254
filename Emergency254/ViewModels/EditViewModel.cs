using System.Threading.Tasks;
using Xamarin.Forms;
using Emergency254.Extensions;
using Emergency254.Utils;
using Emergency254.Shared.Models;
using Plugin.Media;
using System.IO;
using Emergency254.Views;
using System;
using Unity.Injection;
using System.Text.RegularExpressions;

namespace Emergency254.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        readonly bool isNew;
        public EditViewModel()
        {
            Contact = new Contact();
            isNew = true;
            Title = "New Contact";
            
        }
        public EditViewModel(Contact contact)
        {
            if (contact == null)
            {
                Contact = new Contact();
                isNew = true;
                Title = "New Contact";
            }
            else
            {
                Contact = contact.Clone();
                Title = "Edit Contact";
            }


        }

        Command pickCommand;
        public Command PickPhotoCommand => pickCommand = pickCommand ?? (pickCommand = new Command(async () => await ExecutePickPhotoCommand()));
        async Task ExecutePickPhotoCommand()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }
            else
            {
                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });

                if (file == null)
                    return;
                else
                using (var memoryStream = new MemoryStream())
                {
                    file.GetStream().CopyTo(memoryStream);
                    this.Contact.Image = memoryStream.ToArray();
                }
            }
            
        }

        public Contact Contact { private set; get; }

        Command saveCommand;

        public Command SaveCommand => saveCommand ?? (saveCommand = new Command(async () => await ExecuteSaveCommand()));

        async Task ExecuteSaveCommand()
        {
            if (string.IsNullOrWhiteSpace(Contact.LastName) || string.IsNullOrWhiteSpace(Contact.FirstName))
            {
                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Invalid name!",
                    Message = "Your Contacts must have both a first and last name.",
                    Cancel = "OK"
                });
                return;
            }
            if (string.IsNullOrWhiteSpace(Contact.Phone) || string.IsNullOrWhiteSpace(Contact.Email))
            {
                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Invalid contact!",
                    Message = "No email or phone Number.",
                    Cancel = "OK"
                });
                return;
            }
            if (!(Contact.Phone.Length >= 10 || Contact.Phone.Length <=12) && !(Contact.Phone.StartsWith("07") || Contact.Phone.StartsWith("254")))
            {
                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Invalid contact!",
                    Message = "Phone Number is Invalid, please check length.",
                    Cancel = "OK"
                });
                return;
            }
            if(!Contact.Email.Contains("@") && !Contact.Email.Contains(".com") && !(
                Contact.Email.Contains("yahoo") || Contact.Email.Contains("gmail") ||
                Contact.Email.Contains("outlook") || Contact.Email.Contains("Hotmail")))
            {
                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Invalid Detais!",
                    Message = "Are you employed or schooling?",
                    Cancel = "OK"
                });
                return;
            }
            if (string.IsNullOrWhiteSpace(Contact.Company) || string.IsNullOrWhiteSpace(Contact.JobTitle))
            {
                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Invalid Detais!",
                    Message = "Are you employed or schooling?",
                    Cancel = "OK"
                });
                return;
            }
            if (string.IsNullOrWhiteSpace(Contact.PostalCode) || string.IsNullOrWhiteSpace(Contact.City) ||
                string.IsNullOrWhiteSpace(Contact.Street) || string.IsNullOrWhiteSpace(Contact.Street))
            {
                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Invalid name!",
                    Message = "You must provide a city/town, location(mtaa), county or a valid post office number(If P.O.Box is unavailable use 12345).",
                    Cancel = "OK"
                });
                return;
            }
            if (!RequiredAddressFieldCombinationIsFilled)
            {
                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Invalid address!",
                    Message = "You must enter either a street, city, and state combination, or a postal code.",
                    Cancel = "OK"
                });
                return;
            }

            if (isNew)
            {
                var ucode = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(ucode.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("+", "");
                GuidString = GuidString.Replace("/", "");
                GuidString = GuidString.Replace("a", "");
                GuidString = GuidString.Replace("b", "");
                GuidString = GuidString.Replace("c", "");
                GuidString = GuidString.Replace("d", "");
                GuidString = GuidString.Replace("c", "");
                GuidString = GuidString.Replace("d", "");
                GuidString = GuidString.Replace("f", "");
                GuidString = GuidString.Replace("g", "");
                GuidString = GuidString.Replace("h", "");
                GuidString = GuidString.Replace("e", "");
                GuidString = GuidString.Replace("i", "");
                GuidString = GuidString.Replace("j", "");
                GuidString = GuidString.Replace("k", "");
                GuidString = GuidString.Replace("m", "");
                GuidString = GuidString.Replace("o", "");
                GuidString = GuidString.Replace("n", "");
                GuidString = GuidString.Replace("p", "");
                GuidString = GuidString.Replace("q", "");
                GuidString = GuidString.Replace("r", "");
                GuidString = GuidString.Replace("s", "");
                GuidString = GuidString.Replace("t", "");
                GuidString = GuidString.Replace("u", "");
                GuidString = GuidString.Replace("v", "");
                GuidString = GuidString.Replace("w", "");
                GuidString = GuidString.Replace("x", "");
                GuidString = GuidString.Replace("y", "");
                GuidString = GuidString.Replace("z", "");
                Contact.UniqueCodeUser = GuidString;
                await DataSource.AddItem(Contact);
            }
            else
            {
                await DataSource.UpdateItem(Contact);
            }
            await App.Current.MainPage.Navigation.PushAsync(new ProfilePage());
        }

        bool RequiredAddressFieldCombinationIsFilled
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Contact.Street) && !string.IsNullOrWhiteSpace(Contact.City) && !string.IsNullOrWhiteSpace(Contact.State))
                {
                    return true;
                }

                if (!Contact.PostalCode.IsNullOrWhiteSpace() && (Contact.Street.IsNullOrWhiteSpace() || Contact.City.IsNullOrWhiteSpace() || Contact.State.IsNullOrWhiteSpace()))
                {
                    return true;
                }

                if (Contact.AddressString.IsNullOrWhiteSpace())
                {
                    return true;
                }

                return false;
            }
        }
    }
}

