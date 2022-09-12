using ASchryer_Spectrum_List_Project.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ASchryer_Spectrum_List_Project
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new ItemsPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
