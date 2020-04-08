using Android.Content;
using Android.Graphics.Drawables;
using Necessitudo.CustomRenderer;
using Necessitudo.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Material.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace Necessitudo.Droid.CustomRenderer
{
    public class CustomEditorRenderer : MaterialEditorRenderer
    {
        public CustomEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}