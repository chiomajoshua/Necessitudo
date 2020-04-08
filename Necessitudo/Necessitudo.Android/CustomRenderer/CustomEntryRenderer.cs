using Android.Content;
using Necessitudo.CustomRenderer;
using Necessitudo.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Material.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace Necessitudo.Droid.CustomRenderer
{
    public class CustomEntryRenderer : MaterialEntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        [System.Obsolete]
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            
            if (Control != null)
            {
                Control.EditText.Background = null;
                Control.EditText.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}