using Humanizer;
using MvvmHelpers;
using System;
namespace Emergency254.Models
{
	public class Chat: ObservableObject
    {

		public string Phone
		{
			get;
			set;
		}

		public string UserMessage
		{
			get;
			set;
		}
        DateTime messageDateTime;

        public DateTime MessageDateTime
        {
            get { return messageDateTime; }
            set { SetProperty(ref messageDateTime, value); }
        }

        public string MessageTimeDisplay => MessageDateTime.Humanize();

        bool isIncoming;

        public bool IsIncoming
        {
            get { return isIncoming; }
            set { SetProperty(ref isIncoming, value); }
        }

        public bool HasAttachement => !string.IsNullOrEmpty(attachementUrl);

        string attachementUrl;

        public string AttachementUrl
        {
            get { return attachementUrl; }
            set { SetProperty(ref attachementUrl, value); }
        }
    }
}
