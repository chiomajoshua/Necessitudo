using Necessitudo.iOS.CustomRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Material.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace Necessitudo.iOS.CustomRenderer
{
    public class CustomEntryRenderer : MaterialEntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
                Control.Layer.CornerRadius = 10;
                Control.TextColor = UIColor.White;
            }
        }
    }
}