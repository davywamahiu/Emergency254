using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Emergency254.Constants;
using Emergency254.Extensions;
using Emergency254.Models;
using Emergency254.Services;
using MvvmHelpers.Commands;
using Xamarin.Essentials;
using Emergency254.Shared.Models;
using Emergency254.Utils;

namespace Emergency254.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {

        AsyncCommand<string> dialNumberCommand;

        public AsyncCommand<string> DialNumberCommand => 
            dialNumberCommand = dialNumberCommand?? new AsyncCommand<string>(ExecuteDialNumberCommand);

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
            messageNumberCommand = messageNumberCommand?? new AsyncCommand<string>(ExecuteMessageNumberCommand);

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

        AsyncCommand<string> emailCommand;

        public AsyncCommand<string> EmailCommand =>
            emailCommand = emailCommand?? new AsyncCommand<string>(ExecuteEmailCommand);

        async Task ExecuteEmailCommand(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return;

            try
            {
                await Email.ComposeAsync(string.Empty, string.Empty, email);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Not Supported",
                    Message = "Email is not supported on this device.",
                    Cancel = "OK"
                });
            }
        }

        AsyncCommand<Contact> getDirectionsCommand;

        public AsyncCommand<Contact> GetDirectionsCommand =>
            getDirectionsCommand = getDirectionsCommand?? new AsyncCommand<Contact>(ExecuteGetDirectionsCommand);


        async Task ExecuteGetDirectionsCommand(Contact MyContacts)
        {
            try
            {
                await Map.OpenAsync(new Placemark
                {
                    AdminArea = MyContacts.State,
                    Locality = MyContacts.City,
                    PostalCode = MyContacts.PostalCode,
                    Thoroughfare = MyContacts.AddressString
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Dialogs.Alert(new AlertInfo
                {
                    Title = "Not Supported",
                    Message = "Unable to open a map application on the device..",
                    Cancel = "OK"
                });
            }
        }
    }
}
