using Necessitudo.Controls;
using Necessitudo.Services;
using Necessitudo.Views.Onboarding;
using Xamarin.Forms;

namespace Necessitudo
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            MainPage = new ImageNavigationPage(new LandingPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
