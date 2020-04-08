using Android.Content;
using Android.Support.V4.App;
using Necessitudo.Controls;
using Necessitudo.Droid.CustomRenderer;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(ImageNavigationPage), typeof(ImageNavigationPageRenderer))]
namespace Necessitudo.Droid.CustomRenderer
{
    public class ImageNavigationPageRenderer : NavigationPageRenderer 
    {
        private TransitionType _transitionType = TransitionType.Default;
        public ImageNavigationPageRenderer(Context context): base(context)
        {

        }


        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);
            var ct = e.NewElement as ImageNavigationPage;
            _transitionType = ct.TransitionType;


            var bar = (Android.Support.V7.Widget.Toolbar)typeof(NavigationPageRenderer)
                .GetField("_toolbar", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(this);
            
            //actionBar.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.YourImageInDrawable));
           // bar.SetBackgroundResource(Resource.Drawable.toolbar);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == ImageNavigationPage.TransitionTypeProperty.PropertyName)
                UpdateTransitionType();
        }

        protected override void SetupPageTransition(FragmentTransaction transaction, bool isPush)
        {
            switch (_transitionType)
            {
                case TransitionType.None:
                    return;
                case TransitionType.Default:
                    return;
                case TransitionType.Fade:
                    transaction.SetCustomAnimations(Resource.Animation.fade_in, Resource.Animation.fade_out,
                                                    Resource.Animation.fade_out, Resource.Animation.fade_in);
                    break;
                case TransitionType.Flip:
                    transaction.SetCustomAnimations(Resource.Animation.flip_in, Resource.Animation.flip_out,
                                                    Resource.Animation.flip_out, Resource.Animation.flip_in);
                    break;
                case TransitionType.Scale:
                    transaction.SetCustomAnimations(Resource.Animation.scale_in, Resource.Animation.scale_out,
                                                    Resource.Animation.scale_out, Resource.Animation.scale_in);
                    break;
                case TransitionType.SlideFromLeft:
                    if (isPush)
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_left, Resource.Animation.exit_right,
                                                        Resource.Animation.enter_right, Resource.Animation.exit_left);
                    }
                    else
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_right, Resource.Animation.exit_left,
                                                        Resource.Animation.enter_left, Resource.Animation.exit_right);
                    }
                    break;
                case TransitionType.SlideFromRight:
                    if (isPush)
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_right, Resource.Animation.exit_left,
                                                        Resource.Animation.enter_left, Resource.Animation.exit_right);
                    }
                    else
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_left, Resource.Animation.exit_right,
                                                        Resource.Animation.enter_right, Resource.Animation.exit_left);
                    }
                    break;
                case TransitionType.SlideFromTop:
                    if (isPush)
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_top, Resource.Animation.exit_bottom,
                                                        Resource.Animation.enter_bottom, Resource.Animation.exit_top);
                    }
                    else
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_bottom, Resource.Animation.exit_top,
                                                        Resource.Animation.enter_top, Resource.Animation.exit_bottom);
                    }
                    break;
                case TransitionType.SlideFromBottom:
                    if (isPush)
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_bottom, Resource.Animation.exit_top,
                                                        Resource.Animation.enter_top, Resource.Animation.exit_bottom);
                    }
                    else
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_top, Resource.Animation.exit_bottom,
                                                        Resource.Animation.enter_bottom, Resource.Animation.exit_top);
                    }
                    break;
                default:
                    return;
            }
        }


        private void UpdateTransitionType()
        {
            var transitionNavigationPage = (ImageNavigationPage)Element;
            _transitionType = transitionNavigationPage.TransitionType;
        }
    }
}
