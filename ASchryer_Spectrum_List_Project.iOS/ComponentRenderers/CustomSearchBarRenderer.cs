using System;
using ASchryer_Spectrum_List_Project.Components;
using ASchryer_Spectrum_List_Project.iOS.ComponentRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof(CustomSearchBar),typeof(CustomSearchBarRenderer))]
namespace ASchryer_Spectrum_List_Project.iOS.ComponentRenderers
{
    public class CustomSearchBarRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
                Control.BackgroundColor = UIKit.UIColor.FromRGB(200, 200, 200);
        }
    }
}
