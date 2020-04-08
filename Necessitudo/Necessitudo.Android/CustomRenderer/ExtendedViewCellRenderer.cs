using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Necessitudo.Controls;
using Necessitudo.Droid.CustomRenderer;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(handler: typeof(ExtendedViewCell), target: typeof(ExtendedViewCellRenderer))]
namespace Necessitudo.Droid.CustomRenderer
{
    public class ExtendedViewCellRenderer : ViewCellRenderer
    {
        private Android.Views.View _cellCore;
        private Drawable _unselectedBackground;
        private bool _selected;

        protected override Android.Views.View GetCellCore(Cell item,
                                                          Android.Views.View convertView,
                                                          ViewGroup parent,
                                                          Context context)
        {
            _cellCore = base.GetCellCore(item, convertView, parent, context);

            _selected = false;
            _unselectedBackground = _cellCore.Background;

            return _cellCore;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnCellPropertyChanged(sender, args);

            if (args.PropertyName == "IsSelected")
            {
                _selected = !_selected;

                if (_selected)
                {
                    var extendedViewCell = sender as ExtendedViewCell;
                    _cellCore.SetBackgroundColor(extendedViewCell.SelectedBackgroundColor.ToAndroid());
                }
                else
                {
                    _cellCore.SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
            }
        }
    }
}