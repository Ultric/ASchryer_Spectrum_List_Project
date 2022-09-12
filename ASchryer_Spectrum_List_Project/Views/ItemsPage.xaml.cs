using ASchryer_Spectrum_List_Project.Models;
using ASchryer_Spectrum_List_Project.Utilities;
using ASchryer_Spectrum_List_Project.ViewModels;
using ASchryer_Spectrum_List_Project.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ASchryer_Spectrum_List_Project.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        async void ItemsListView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count == 0)
                return;

            var selectedContact = e.CurrentSelection[0] as Contact;
            if (selectedContact == null)
                return;

            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(selectedContact)));
            await Navigation.PushModalAsync(new ItemDetailPage(new ItemDetailViewModel(selectedContact)));

            ItemsListView.SelectedItem = null;
        }

        void SearchBar_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            var searchBar = sender as Entry;
            if (searchBar == null)
                return;

            ItemsListView.ItemsSource = RandomContactList.FilterContactList(e.NewTextValue);
        }
    }
}