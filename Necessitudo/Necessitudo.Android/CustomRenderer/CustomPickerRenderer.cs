using Android.Content;
using Necessitudo.CustomRenderer;
using Necessitudo.Droid.CustomRenderer;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Material.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace Necessitudo.Droid.CustomRenderer
{
    public class CustomPickerRenderer : MaterialPickerRenderer
    {
        public CustomPickerRenderer(Context context) : base(context)
        {
        }

        [Obsolete]
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}