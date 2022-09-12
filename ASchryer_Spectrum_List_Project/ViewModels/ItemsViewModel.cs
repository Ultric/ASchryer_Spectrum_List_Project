using ASchryer_Spectrum_List_Project.Models;
using ASchryer_Spectrum_List_Project.Utilities;
using ASchryer_Spectrum_List_Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ASchryer_Spectrum_List_Project.ViewModels
{
    public class ItemsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public Command LoadItemsCommand { get; }
        public Command<Contact> ItemTapped { get; }

        public ObservableCollection<Contact> ContactList { get;  }

        public RandomContactList Contacts { get; set; }
        public string currentSeed { get; set; }

        public ItemsViewModel()
        {
            Title = "Contacts";

            ContactList = new ObservableCollection<Contact>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            Debug.WriteLine("Reloading");

            IsBusy = true;

            try
            {
                Contacts = await RandomContactList.GenerateContactLot(25);

                this.currentSeed = Contacts.seed;

                if (Contacts.results.Count > 0)
                {
                    ContactList.Clear();
                    foreach (var contact in Contacts.results)
                    {
                        Debug.WriteLine(contact.nameString);
                        ContactList.Add(contact);
                    }

                    RandomContactList.ContactList = new List<Contact>(ContactList);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            if (RandomContactList.ContactList.Count == 0)
                IsBusy = true;
        }

        public event PropertyChangedEventHandler PropertyChangedHandler;   

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedHandler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}