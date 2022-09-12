using System;
using System.Linq;
using ASchryer_Spectrum_List_Project.Effects;
using ASchryer_Spectrum_List_Project.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("ASchryer")]
[assembly: ExportEffect(typeof(LabelColorizeEffect), "LabelColorizeEffect")]
namespace ASchryer_Spectrum_List_Project.iOS.Effects
{
    public class LabelColorizeEffect : PlatformEffect
    {
        public LabelColorizeEffect()
        {
        }

        protected override void OnAttached()
        {
            var control = Control as UILabel;
            var effect = (LabelColorizeEffectX)Element.Effects.FirstOrDefault(e => e is LabelColorizeEffectX);
            if (effect!=null)
                control.TextColor = effect.Color.ToUIColor();
        }

        protected override void OnDetached()
        {
        }
    }
}
