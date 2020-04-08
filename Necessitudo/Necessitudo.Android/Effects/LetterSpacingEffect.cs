using System;
using System.Linq;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("necessitudo")]
[assembly: ExportEffect(typeof(Necessitudo.Droid.Effects.LetterSpacingEffect), "LetterSpacingEffect")]

namespace Necessitudo.Droid.Effects
{
    public class LetterSpacingEffect : PlatformEffect
    {
        

        protected override void OnAttached()
        {
            var effect = (AttachedProperties.LetterSpacingEffect)Element.Effects.Where(a => a is AttachedProperties.LetterSpacingEffect).FirstOrDefault();
            if (effect != null)
            {
                var label = Control as TextView;
                label.LetterSpacing = effect.LetterSpace;
            }
        }

        protected override void OnDetached()
        {
            //do nothing
        }
    }
}
