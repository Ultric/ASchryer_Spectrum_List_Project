using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ASchryer_Spectrum_List_Project.Behaviors
{
    public class NoNumbersSearchBarBehavior : Behavior<Entry>
    {
        private List<string> invalidCharacters = new List<string> { "1","2","3","4","5","6","7","8","9","0","-","=","!","@","#","$","%","^","&","*","&","(",")","_","+" };
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnSearchTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnSearchTextChanged;
            base.OnDetachingFrom(bindable);
        }

        void OnSearchTextChanged (object sender, TextChangedEventArgs args)
        {
            bool isValidSearchTerm = !invalidCharacters.Any(args.NewTextValue.Contains);
            ((Entry)sender).TextColor = isValidSearchTerm ? Color.Black : Color.Red;
        }
    }
}
