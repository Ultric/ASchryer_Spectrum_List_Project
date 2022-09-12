using System;
using Android.Content;
using ASchryer_Spectrum_List_Project.Components;
using ASchryer_Spectrum_List_Project.Droid.ComponentRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
namespace ASchryer_Spectrum_List_Project.Droid.ComponentRenderers
{
    class CustomSearchBarRenderer : EntryRenderer
    {
        public CustomSearchBarRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
                Control.SetBackgroundColor(Android.Graphics.Color.Rgb(200,200,200));
        }
    }
}
