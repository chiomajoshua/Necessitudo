using Necessitudo.CustomRenderer;
using Necessitudo.iOS.CustomRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Material.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace Necessitudo.iOS.CustomRenderer
{
    public class CustomPickerRenderer : MaterialPickerRenderer
    {
        public CustomPickerRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                return;
            }

            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}