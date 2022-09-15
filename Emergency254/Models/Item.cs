using Emergency254.ViewModels;

using MvvmHelpers.Commands;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Emergency254.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Icon
        {
            get;
            set;
        }
        public string Icon1
        {
            get;
            set;
        }
        public string Icon2
        {
            get;
            set;
        }
        public string Icon3
        {
            get;
            set;
        }
        public string Icon4
        {
            get;
            set;
        }
        public string Icon5
        {
            get;
            set;
        }
        public string Symptoms
        {
            get;
            set;
        }
        public string FirstAid
        {
            get;
            set;
        }
        public string Prevention
        {
            get;
            set;
        }
        public string Prevention1
        {
            get;
            set;
        }
        public string Prevention2
        {
            get;
            set;
        }
        public string Prevention3
        {
            get;
            set;
        }
        public string Prevention4
        {
            get;
            set;
        }
        public string Prevention5
        {
            get;
            set;
        }
        public string Prevention6
        {
            get;
            set;
        }
        public string Others
        {
            get;
            set;
        }
        public string Sub1
        {
            get;
            set;
        }
        public string Sub2
        {
            get;
            set;
        }
        public string Sub3
        {
            get;
            set;
        }
        public string Sub4
        {
            get;
            set;
        }
        public string Sub5
        {
            get;
            set;
        }
        public string Sub6
        {
            get;
            set;
        }
        public string Sub7
        {
            get;
            set;
        }
        public string Sub8
        {
            get;
            set;
        }
        public string Final
        {
            get;
            set;
        }
        public Command ReadCommand { get; }
        public Command SharethisMessage { get; }
        public Item()
        {
            SharethisMessage = new Command(async () => await ExecuteShareCommand());
            ReadCommand = new Command(async () => await ExecuteReadCommand());
        }
        public Item(Item item)
        {

        }
        async Task ExecuteReadCommand()
        {

        }

        async Task ExecuteShareCommand()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = "https://www.googleplay.com/?search=emergency254",
                Title = "Share",
                Text = Text,
                Subject = "Nice message for you."
            });
        }
}
}