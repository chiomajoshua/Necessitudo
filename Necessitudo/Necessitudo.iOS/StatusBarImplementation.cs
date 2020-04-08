using Necessitudo.iOS;
using Necessitudo.Services;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarImplementation))]
namespace Necessitudo.iOS
{
    public class StatusBarImplementation : IStatusBar
    {
        public StatusBarImplementation()
        {
        }

        #region IStatusBarimplementation

        public void HideStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = true;
        }

        public void ShowStatusBar()
        {
            UIApplication.SharedApplication.StatusBarHidden = false;
        }

        #endregion
    }
}