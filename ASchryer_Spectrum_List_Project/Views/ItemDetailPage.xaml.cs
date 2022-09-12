using ASchryer_Spectrum_List_Project.Models;
using ASchryer_Spectrum_List_Project.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ASchryer_Spectrum_List_Project.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage()
        {
            InitializeComponent();

            var contact = new Contact();

            viewModel = new ItemDetailViewModel(contact);
            BindingContext = viewModel;
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        void BackButton_Released(System.Object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}