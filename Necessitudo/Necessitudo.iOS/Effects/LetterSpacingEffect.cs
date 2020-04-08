using System;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("necessitudo")]
[assembly: ExportEffect(typeof(Necessitudo.iOS.Effects.LetterSpacingEffect), "LetterSpacingEffect")]
namespace Necessitudo.iOS.Effects
{
    public class LetterSpacingEffect : PlatformEffect
    {
        public LetterSpacingEffect()
        {
        }

        protected override void OnAttached()
        {
            var effect = (AttachedProperties.LetterSpacingEffect)Element.Effects.Where(a => a is AttachedProperties.LetterSpacingEffect).FirstOrDefault();
            if (effect != null)
            {
                


                    var ctrl = Control as UILabel;
                    var text = ctrl.Text;
                if (string.IsNullOrEmpty(text)) return;
                    var attributedString = new NSMutableAttributedString(text);

                    var nsKern = new NSString("NSKern");
                    var spacing = NSObject.FromObject(effect.LetterSpace * 10);
                    var range = new NSRange(0, text.Length);

                    attributedString.AddAttribute(nsKern, spacing, range);
                    ctrl.AttributedText = attributedString;
                


            }
        }

        protected override void OnDetached()
        {
            //do nothing
        }
    }
}
