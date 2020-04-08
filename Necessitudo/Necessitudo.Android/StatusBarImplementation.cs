using Android.App;
using Android.Views;
using Necessitudo.Droid;
using Necessitudo.Services;
using System;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarImplementation))]
namespace Necessitudo.Droid
{
    public class StatusBarImplementation : IStatusBar
    {
        public StatusBarImplementation()
        {
        }

        WindowManagerFlags _originalFlags;

        #region IStatusBarImplementation

        [Obsolete]
        public void HideStatusBar()
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            _originalFlags = attrs.Flags;
            attrs.Flags |= Android.Views.WindowManagerFlags.Fullscreen;
            activity.Window.Attributes = attrs;
        }

        [Obsolete]
        public void ShowStatusBar()
        {
            var activity = (Activity)Forms.Context;
            var attrs = activity.Window.Attributes;
            attrs.Flags = _originalFlags;
            activity.Window.Attributes = attrs;
        }

        #endregion
    }
}