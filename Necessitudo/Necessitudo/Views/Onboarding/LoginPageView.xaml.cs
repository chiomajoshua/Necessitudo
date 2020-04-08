using Necessitudo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Necessitudo.Views.Onboarding
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPageView : ContentPage
    {
        public LoginPageView()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            DependencyService.Get<IStatusBar>().HideStatusBar();
            InitializeComponent();
        }
    }
}