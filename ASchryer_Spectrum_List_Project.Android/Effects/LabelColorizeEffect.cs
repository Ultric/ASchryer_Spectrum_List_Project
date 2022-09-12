using System;
using System.Linq;
using ASchryer_Spectrum_List_Project.Droid.Effects;
using ASchryer_Spectrum_List_Project.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName ("ASchryer")]
[assembly: ExportEffect (typeof(LabelColorizeEffect), "LabelColorizeEffect")]
namespace ASchryer_Spectrum_List_Project.Droid.Effects
{
    public class LabelColorizeEffect : PlatformEffect
    {
        public LabelColorizeEffect()
        {
        }

        protected override void OnAttached()
        {
            var control = Control as Android.Widget.TextView;
            var effect = (LabelColorizeEffectX)Element.Effects.FirstOrDefault(e => e is LabelColorizeEffectX);
            if (effect != null)
                control.SetTextColor(effect.Color.ToAndroid());
            
        }

        protected override void OnDetached()
        {
        }
    }
}
