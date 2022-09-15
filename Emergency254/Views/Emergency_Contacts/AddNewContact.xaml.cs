using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Emergency254.Views.Emergency_Contacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewContact : ContentPage
    {
        protected ContactsViewmodels contactsViewmodels => BindingContext as ContactsViewmodels;
        public AddNewContact()
        {
            InitializeComponent();
            BindingContext = new ContactsViewmodels();
        }
    }
}