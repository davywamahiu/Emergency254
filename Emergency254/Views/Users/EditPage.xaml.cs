﻿using System.ComponentModel;
using Emergency254.Models;
using Emergency254.Shared.Models;
using Emergency254.ViewModels;
using Plugin.Media;
using Xamarin.Forms;

namespace Emergency254.Views
{
    public partial class EditPage : ContentPage
    {
		protected EditViewModel ViewModel => BindingContext as EditViewModel;

        public EditPage()
        {
            InitializeComponent();
            BindingContext = new EditViewModel();
        }

        public EditPage(Contact contact) 
        {
            InitializeComponent();
            BindingContext = new EditViewModel(contact);
        }

        

        /// <summary>
        /// Ensures the state field has 2 characters at most.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The PropertyChangedEventArgs</param>
        void StateEntry_PropertyChanged (object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text")
            {
                var entryCell = sender as EntryCell;

                var val = entryCell.Text;

				if (val != null)
				{

					if (val.Length > 2)
					{
						val = val.Remove(val.Length - 1);
					}

					entryCell.Text = val.ToUpperInvariant();
				}
            }
        }

        /// <summary>
        /// Ensures the zip code field has 5 characters at most.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The PropertyChangedEventArgs</param>
        void PostalCode_PropertyChanged (object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text")
            {
                var entryCell = sender as EntryCell;

                var val = entryCell.Text;

				if (val != null && val.Length > 5)
                {
                    val = val.Remove(val.Length - 1);
                    entryCell.Text = val;
                }
            }
            
        }
    }
}

