using Necessitudo.CustomRenderer;
using Necessitudo.Droid.CustomRenderer;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace Necessitudo.Droid.CustomRenderer
{
    [Obsolete]
    public class BorderlessEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}