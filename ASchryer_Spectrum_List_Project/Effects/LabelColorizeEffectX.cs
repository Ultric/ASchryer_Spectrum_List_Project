using System;
using Xamarin.Forms;

namespace ASchryer_Spectrum_List_Project.Effects
{
    public class LabelColorizeEffectX : RoutingEffect
    {
        public LabelColorizeEffectX() : base($"ASchryer.LabelColorizeEffect")
        {
        }

        public Color Color { get; set; }
    }
}
