using ASchryer_Spectrum_List_Project.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ASchryer_Spectrum_List_Project.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Contact contact { get; set; }

        public ItemDetailViewModel(Contact contact = null)
        {
            this.contact = contact;
        }
    }
}
